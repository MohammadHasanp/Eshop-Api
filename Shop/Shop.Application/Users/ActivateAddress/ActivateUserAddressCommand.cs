
using Common.Application;

namespace Shop.Application.Users.ActivateAddress
{
    public record ActivateUserAddressCommand(long UserId,long AddressId):IBaseCommand;
}
