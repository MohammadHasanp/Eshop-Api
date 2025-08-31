using Common.Application;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.DeleteAddress;
using Shop.Application.Users.EditAddress;

namespace Shop.Presentation.Facade.UserAgg.UserAddress
{
    public interface IUserAddressFacade
    {
        Task<OperationResult> AddUserAddress(AddUserAddressCommand command);
        Task<OperationResult> DeleteUserAddress(DeleteUserAddressCommand command);
        Task<OperationResult> EditUserAddress(EditUserAddressCommand command);
    }
}
