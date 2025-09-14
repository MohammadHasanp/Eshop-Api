using AutoMapper;
using Common.AspNetCore;
using Common.AspNetCore.ClaimUtils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.Api.ViewModel.Users;
using Shop.Application.Users.ChangePassword;
using Shop.Application.Users.Create;
using Shop.Application.Users.Edit;
using Shop.Application.Users.EditAddress;
using Shop.Domain.RoleAgg.Enums;
using Shop.Presentation.Facade.UserAgg;
using Shop.Query.UserAgg.DTOs;
namespace Shop.Api.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        private readonly IUserFacade _userFacade;
        private readonly IMapper _mapper;
        public UserController(IUserFacade userFacade, IMapper mapper)
        {
            _userFacade = userFacade;
            _mapper = mapper;
        }
        [PermissionChecker(Permission.User_Management)]
        [HttpGet]
        public async Task<ApiResult<List<UserDto>>> GetAll()
        {
            var result = await _userFacade.GetAllUser();
            return QueryResult(result);
        }
        [Authorize]
        [HttpGet("Current")]
        public async Task<ApiResult<UserDto>> GetCurrentUser()
        {
            var result = await _userFacade.GetUserById(User.GetUserId());
            return QueryResult(result);
        }
        [PermissionChecker(Permission.User_Management)]
        [HttpGet("GetByFilter")]
        public async Task<ApiResult<UserFilterResult>> GetByFilter([FromQuery] UserFilterParams @params)
        {
            var result = await _userFacade.GetUserByFilter(@params);
            return QueryResult(result);
        }
        [PermissionChecker(Permission.User_Management)]
        [HttpGet("byId/{UserId}")]
        public async Task<ApiResult<UserDto>> GetById(long UserId)
        {
            var result = await _userFacade.GetUserById(UserId);
            return QueryResult(result);
        }
        //[HttpGet("GetByPhone/{PhoneNumber}")]
        //public async Task<ApiResult<UserDto>> GetByPhone(string PhoneNumber)
        //{
        //    var result = await _userFacade.GetUserByPhoneNumber(PhoneNumber);
        //    return QueryResult(result);
        //}
        //[HttpGet("GetByEmail/{Email}")]
        //public async Task<ApiResult<UserDto>> GetByEmail(string Email)
        //{
        //    var result = await _userFacade.GetUserByEmail(Email);
        //    return QueryResult(result);
        //}
        [HttpPost]
        [PermissionChecker(Permission.User_Management)]
        public async Task<ApiResult> CreateUser(CreateUserCommand command)
        {
            var result = await _userFacade.Create(command);
            return CommandResult(result);
        }
        [HttpPut("Edit")]
        [PermissionChecker(Permission.User_Management)]
        public async Task<ApiResult> EditUser([FromForm]EditUserCommand command)
        {
            var result = await _userFacade.Edit(command);
            return CommandResult(result);
        }

        [HttpPut("Current")]
        public async Task<ApiResult> EditUserCurrent([FromForm]EditUserViewModel viewModel)
        {
            var userModel = new EditUserCommand(viewModel.UserName, viewModel.FullName, viewModel.Email
                , viewModel.PhoneNumber, viewModel.Gender, viewModel.Avatar, User.GetUserId());

            var result = await _userFacade.Edit(userModel);
            return CommandResult(result);
        }

        [HttpPut("ChangePassword")]
        [Authorize]
        public async Task<ApiResult> ChangePassword(ChangePasswordViewModel viewModel)
        {
            var changePasswordModel = _mapper.Map<ChangeUserPasswordCommand>(viewModel);
            changePasswordModel.UserId = User.GetUserId();
            var result = await _userFacade.ChangePassword(changePasswordModel);
            return CommandResult(result);

        }
    }
}
