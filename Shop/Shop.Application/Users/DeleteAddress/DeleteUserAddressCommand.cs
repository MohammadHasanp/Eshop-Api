using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.DeleteAddress
{
    public class DeleteUserAddressCommand:IBaseCommand
    {
        public long UserId { get; private set; }
        public long AddressId { get; set; }

        public DeleteUserAddressCommand(long userId, long addressId)
        {
            UserId = userId;
            AddressId = addressId;
        }
    }
}
