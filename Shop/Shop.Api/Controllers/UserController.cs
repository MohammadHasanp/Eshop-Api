using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Users.Create;
using Shop.Application.Users.Edit;
using Shop.Application.Users.EditAddress;
using Shop.Presentation.Facade.UserAgg;
using Shop.Query.UserAgg.DTOs;
namespace Shop.Api.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserFacade _userFacade;

        public UserController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [HttpGet]
        public async Task<ApiResult<List<UserDto>>>GetAll()
        {
            var result = await _userFacade.GetAllUser();
            return QueryResult(result);
        }

        [HttpGet("GetByFilter")]
        public async Task<ApiResult<UserFilterResult>> GetByFilter([FromQuery] UserFilterParams @params)
        {
            var result = await _userFacade.GetUserByFilter(@params);
            return QueryResult(result);
        }
        [HttpGet("byId/{UserId}")]
        public async Task<ApiResult<UserDto>> GetById(long UserId)
        {
            var result = await _userFacade.GetUserById(UserId);
            return QueryResult(result);
        }
        //[HttpGet("GetByPhone/{Phone}")]
        //public async Task<ApiResult<UserDto>> GetByPhone(string Phone)
        //{
        //    var result = await _userFacade.GetUserByPhoneNumber(Phone);
        //    return QueryResult(result);
        //}
        //[HttpGet("GetByEmail/{Email}")]
        //public async Task<ApiResult<UserDto>> GetByEmail(string Email)
        //{
        //    var result = await _userFacade.GetUserByEmail(Email);
        //    return QueryResult(result);
        //}
        [HttpPost]
        public async Task<ApiResult> CreateUser(CreateUserCommand command) 
        {
            var result = await _userFacade.Create(command);
            return CommandResult(result);
        }
        [HttpPut]
        public async Task<ApiResult>EditUser(EditUserCommand command)
        {
            var result = await _userFacade.Edit(command);
            return CommandResult(result);
        }
    }
}
