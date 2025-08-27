using Shop.Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.UserAgg.Services
{
    public class UserDomainService : IUserDomainService
    {
        public bool IsEmailExist(string email)
        {
            throw new NotImplementedException();
        }

        public bool IsPhoneNumberExist(string phone)
        {
            throw new NotImplementedException();
        }
    }
}
