using Common.Application;
using Shop.Domain.UserAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.Create
{
    public class CreateUserCommand : IBaseCommand
    {
        public string UserName { get; private set; }
        public string FullName { get; private set; }
        public string Password { get; set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public Gender Gender { get; private set; }

        public CreateUserCommand(string userName, string fullName, string password, string email, string phoneNumber
            , Gender gender)
        {
            UserName = userName;
            FullName = fullName;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
            Gender = gender;
        }
    }
}
