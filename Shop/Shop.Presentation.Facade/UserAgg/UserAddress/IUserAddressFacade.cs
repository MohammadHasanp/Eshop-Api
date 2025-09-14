using Common.Application;
using Shop.Application.Users.ActivateAddress;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.DeleteAddress;
using Shop.Application.Users.EditAddress;
using Shop.Query.UserAgg.DTOs;

namespace Shop.Presentation.Facade.UserAgg.UserAddress
{
    public interface IUserAddressFacade
    {
        Task<OperationResult> AddUserAddress(AddUserAddressCommand command);
        Task<OperationResult> DeleteUserAddress(DeleteUserAddressCommand command);
        Task<OperationResult> EditUserAddress(EditUserAddressCommand command);
        Task<OperationResult> ActivateUserAddress(ActivateUserAddressCommand command);
        Task<AddressDto> GetAddressById(long AddressId);
        Task<List<AddressDto>> GetAllUserAddress(long UserId);
    }
}
