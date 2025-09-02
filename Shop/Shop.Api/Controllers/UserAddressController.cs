using Common.AspNetCore;

using Shop.Presentation.Facade.UserAgg.UserAddress;

namespace Shop.Api.Controllers
{
    public class UserAddressController : ApiController
    {
        private readonly IUserAddressFacade _userAddressFacade;
        
        public UserAddressController(IUserAddressFacade userAddressFacade)
        {
            _userAddressFacade = userAddressFacade;
        }
    }
}
