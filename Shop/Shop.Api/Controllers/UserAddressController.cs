using AutoMapper;
using Common.AspNetCore;
using Common.AspNetCore.ClaimUtils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModel.Users;
using Shop.Application.Users.ActivateAddress;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.DeleteAddress;
using Shop.Application.Users.EditAddress;
using Shop.Presentation.Facade.UserAgg.UserAddress;
using Shop.Query.UserAgg.DTOs;

namespace Shop.Api.Controllers
{
    public class UserAddressController : ApiController
    {
        private readonly IUserAddressFacade _userAddressFacade;
        private readonly IMapper _mapper;
        public UserAddressController(IUserAddressFacade userAddressFacade, IMapper mapper)
        {
            _userAddressFacade = userAddressFacade;
            _mapper = mapper;
        }
        [HttpGet("GetAddressBy{AddressId}")]
        public async Task<ApiResult<AddressDto>> GetUserAddressById(long AddressId)
        {
            var result = await _userAddressFacade.GetAddressById(AddressId);
            return QueryResult(result);
        }
        [HttpGet]
        public async Task<ApiResult<List<AddressDto>>> GetAllAddress()
        {
            var result = await _userAddressFacade.GetAllUserAddress(User.GetUserId());
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> AddUserAddress(AddUserAddressViewModel viewModel)
        {
            Console.WriteLine("Request reached here");
            var command = _mapper.Map<AddUserAddressCommand>(viewModel);
            command.UserId = User.GetUserId();
            var result = await _userAddressFacade.AddUserAddress(command);
            return CommandResult(result);
        }
        [HttpPut]
        public async Task<ApiResult> EditUserAddress(EditUserAddressViewModel viewModel)
        {
            var command = _mapper.Map<EditUserAddressCommand>(viewModel);
            command.UserId =User.GetUserId();
            var result = await _userAddressFacade.EditUserAddress(command);
            return CommandResult(result);
        }
        [HttpDelete("{addressId}")]
        public async Task<ApiResult> DeleteUserAddress(long addressId)
        {
            var model = new DeleteUserAddressCommand(User.GetUserId(),addressId);
            var result = await _userAddressFacade.DeleteUserAddress(model);
            return CommandResult(result);
        }
        [HttpPut("ActivateById/{addressId}")]
        public async Task<ApiResult> ActivateUserAddress(long addressId)
        {
            var model = new ActivateUserAddressCommand(User.GetUserId(),addressId);
            var result = await _userAddressFacade.ActivateUserAddress(model);
            return CommandResult(result);
        }
    }
}
