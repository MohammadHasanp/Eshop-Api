
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.UserAgg.Services
{
    public interface IUserDomainService
    {
        //Existence of email
        bool IsEmailExist(string email);
        //Existence of Phone
        bool IsPhoneNumberExist(string phone);
    }
}
