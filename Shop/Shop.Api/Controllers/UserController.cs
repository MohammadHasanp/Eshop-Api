using AutoMapper;
using Common.AspNetCore;
using Common.AspNetCore.Utilities;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModel.Users;
using Shop.Application.Users.AddUserRole;
using Shop.Application.Users.ChangePassword;
using Shop.Application.Users.Create;
using Shop.Application.Users.Edit;
using Shop.Application.Users.SetActive;
using Shop.Presentation.Facade.UserAgg;
using Shop.Query.UserAgg.DTOs;
namespace Shop.Api.Controllers
{
    //[Authorize]
    public class UserController(IUserFacade userFacade, IMapper mapper) : ApiController
    {
        //[PermissionChecker(Permission.User_Management)]
        [HttpGet]
        public async Task<ApiResult<List<UserDto>>> GetAll()
        {
            var result = await userFacade.GetAllUser();
            return QueryResult(result);
        }
        //[Authorize]
        [HttpGet("Current")]
        public async Task<ApiResult<UserDto>> GetCurrentUser()
        {
            var result = await userFacade.GetUserById(User.GetUserId());
            return QueryResult(result);
        }
        //[PermissionChecker(Permission.User_Management)]
        [HttpGet("GetByFilter")]
        public async Task<ApiResult<UserFilterResult>> GetByFilter([FromQuery] UserFilterParams @params)
        {
            var result = await userFacade.GetUserByFilter(@params);
            return QueryResult(result);
        }
        //[PermissionChecker(Permission.User_Management)]
        [HttpGet("byId/{userId}")]
        public async Task<ApiResult<UserDto>> GetById(long userId)
        {
            var result = await userFacade.GetUserById(userId);
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
        //[PermissionChecker(Permission.User_Management)]
        public async Task<ApiResult> CreateUser(CreateUserCommand command)
        {
            var result = await userFacade.Create(command);
            return CommandResult(result);
        }
        [HttpPut("Edit")]
        //[PermissionChecker(Permission.User_Management)]
        public async Task<ApiResult> EditUser([FromForm]EditUserModel userModel)
        {
            var model = new EditUserCommand(userModel.UserName,"test",userModel.Email,userModel.PhoneNumber,
                userModel.Gender,userModel.Avatar,userModel.UserId);

            var result = await userFacade.Edit(model);
            return CommandResult(result);
        }

        [HttpPut("Current")]
        public async Task<ApiResult> EditUserCurrent([FromForm]EditUserViewModel viewModel)
        {
            var userModel = new EditUserCommand(viewModel.UserName, viewModel.FullName, viewModel.Email
                , viewModel.PhoneNumber, viewModel.Gender, viewModel.Avatar, User.GetUserId());

            var result = await userFacade.Edit(userModel);
            return CommandResult(result);
        }

        [HttpPut("ChangePassword")]
        //[Authorize]
        public async Task<ApiResult> ChangePassword(ChangePasswordViewModel viewModel)
        {
            var changePasswordModel = mapper.Map<ChangeUserPasswordCommand>(viewModel);
            changePasswordModel.UserId = User.GetUserId();
            var result = await userFacade.ChangePassword(changePasswordModel);
            return CommandResult(result);

        }
        [HttpPost("SetActive")]
        public async Task<ApiResult> SetActive(SetActiveUserCommand command)
        {
            var result = await userFacade.SetActive(command);
            return CommandResult(result);
        }
        [HttpPost("AddUserRole")]
        public async Task<ApiResult> AddUserRole(AddUserRoleCommand command)
        {
            var result = await userFacade.AddUserRole(command);
            return CommandResult(result);
        }
    }
}
