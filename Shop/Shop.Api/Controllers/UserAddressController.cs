using AutoMapper;
using Common.AspNetCore;
using Common.AspNetCore.ClaimUtils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModel.Users;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.EditAddress;
using Shop.Presentation.Facade.UserAgg.UserAddress;
using Shop.Query.UserAgg.DTOs;

namespace Shop.Api.Controllers
{
    [Authorize]
    public class UserAddressController : ApiController
    {
        private readonly IUserAddressFacade _userAddressFacade;
        private readonly IMapper _mapper;
        public UserAddressController(IUserAddressFacade userAddressFacade, IMapper mapper)
        {
            _userAddressFacade = userAddressFacade;
            _mapper = mapper;
        }
        [HttpGet("{AddressId}")]
        public async Task<ApiResult<AddressDto>> GetUserAddressById(long AddressId)
        {
            var result = await _userAddressFacade.GetAddressById(AddressId);
            return QueryResult(result);
        }
        [HttpGet("GetAddrerss/{UserId}")]
        public async Task<ApiResult<List<AddressDto>>> GetAllAddress(long UserId)
        {
            var result = await _userAddressFacade.GetAllUserAddress(UserId);
            return QueryResult(result);
        }

        [HttpPost("UserAddress")]
        public async Task<ApiResult> AddUserAddress(AddUserAddressViewModel viewModel)
        {
            var command = _mapper.Map<AddUserAddressCommand>(viewModel);
            command.UserId = User.GetUserId();
            var result = await _userAddressFacade.AddUserAddress(command);
            return CommandResult(result);
        }
        [HttpPut]
        public async Task<ApiResult> EditUserAddress(EditUserAddressViewModel viewModel)
        {
            var command = _mapper.Map<EditUserAddressCommand>(viewModel);
            command.UserId = User.GetUserId();
            var result = await _userAddressFacade.EditUserAddress(command);
            return CommandResult(result);
        }
    }
}
