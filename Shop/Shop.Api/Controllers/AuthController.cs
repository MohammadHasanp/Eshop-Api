using AngleSharp.Browser;
using Azure.Core;
using Common.Application;
using Common.Application.SecurityUtil;
using Common.AspNetCore;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.JwtUtil;
using Shop.Api.ViewModel.Auth;
using Shop.Application.Users.AddToken;
using Shop.Application.Users.Register;
using Shop.Application.Users.RemoveToken;
using Shop.Presentation.Facade.UserAgg;
using Shop.Query.UserAgg.DTOs;
using UAParser;

namespace Shop.Api.Controllers
{
    public class AuthController : ApiController
    {
        private readonly IUserFacade _userFacade;
        private readonly IConfiguration _configuration;
        public AuthController(IUserFacade userFacade, IConfiguration configuration)
        {
            _userFacade = userFacade;
            _configuration = configuration;
        }
        [HttpPost("Login")]
        public async Task<ApiResult<LoginResultDto?>> Login(LoginUserViewModel viewModel)
        {
            var user = await _userFacade.GetUserByPhoneNumber(viewModel.PhoneNumber);
            if (user == null)
            {
                var result = OperationResult<LoginResultDto>.Error("کاربری با مشخصات وارد شده یافت نشد");
                return CommandResult(result);
            }

            if (Sha256Hasher.IsCompare(user.Password, viewModel.Password) == false)
            {
                var result = OperationResult<LoginResultDto>.Error("کاربری با مشخصات وارد شده یافت نشد");
                return CommandResult(result);
            }

            if (user.IsActive == false)
            {
                var result = OperationResult<LoginResultDto>.Error("حساب کاربری شما غیرفعال است");
                return CommandResult(result);
            }

            var loginResult = await AddTokenAndGenerateJwt(user);
            return CommandResult(loginResult);
        }
        [HttpPost("Register")]
        public async Task<ApiResult> Register(RegisterUserViewModel viewModel)
        {
            var command = new RegisterUserCommand(new PhoneNumber(viewModel.PhoneNumber), viewModel.Password);
            var result = await _userFacade.Register(command);
            return CommandResult(result);
        }
        [HttpDelete("Logout")]
        public async Task<ApiResult> Logout()
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer","");

            if (token == null)
                return CommandResult(OperationResult.NotFound("توکن یافت نشد"));

            var userToken = await _userFacade.GetUserTokenByJwtTokenQuery(token);

            if (userToken == null)
                return CommandResult(OperationResult.NotFound("توکن نامعتبر "));

            var result = await _userFacade.RemoveToken(new RemoveUserTokenCommand(userToken.UserId, userToken.Id));

            if (result.Status != OperationResultStatus.Success)
                return CommandResult(OperationResult.Error("عملیات با شکست مواجه شد"));

            return CommandResult(OperationResult.Success("کاربر مورد نظر از سایت خارج شد"));
        }

        [HttpPost("RefreshToken")]
        public async Task<ApiResult<LoginResultDto?>> RefreshToken(string refreshToken)
        {
            var result = await _userFacade.GetUserTokenByRefreshToken(refreshToken);

            if (result == null)
                return CommandResult(OperationResult<LoginResultDto?>.NotFound());

            if (result.TokenExpireDate > DateTime.Now)
            {
                return CommandResult(OperationResult<LoginResultDto>.Error("توکن هنوز منقضی نشده است"));
            }

            if (result.RefreshTokenExpireDate < DateTime.Now)
            {
                return CommandResult(OperationResult<LoginResultDto>.Error("زمان رفرش توکن به پایان رسیده است"));
            }
            var user = await _userFacade.GetUserById(result.UserId);
            var hashRefreshtoken = await _userFacade.RemoveToken(new RemoveUserTokenCommand(result.UserId, result.Id));
            var loginResult = await AddTokenAndGenerateJwt(user);
            return CommandResult(loginResult);
        }

        private async Task<OperationResult<LoginResultDto?>> AddTokenAndGenerateJwt(UserDto user)
        {
            var uaParser = Parser.GetDefault();
            var header = HttpContext.Request.Headers["user-agent"].ToString();
            var device = "windows";
            if (header != null)
            {
                var info = uaParser.Parse(header);
                device = $"{info.Device.Family}/{info.OS.Family} {info.OS.Major}.{info.OS.Minor} - {info.UA.Family}";
            }

            var token = JwtTokenBuilder.BuildToken(user, _configuration);
            var refreshToken = Guid.NewGuid().ToString();

            var hashJwt = Sha256Hasher.Hash(token);
            var hashRefreshToken = Sha256Hasher.Hash(refreshToken);

            var tokenResult = await _userFacade.AddToken(new AddUserTokenCommand(user.Id, hashJwt, hashRefreshToken, DateTime.Now.AddDays(7), DateTime.Now.AddDays(8), device));
            if (tokenResult.Status != OperationResultStatus.Success)
                return OperationResult<LoginResultDto?>.Error();

            return OperationResult<LoginResultDto?>.Success(new LoginResultDto()
            {
                Token = token,
                RefreshToken = refreshToken
            });
        }
    }
}
