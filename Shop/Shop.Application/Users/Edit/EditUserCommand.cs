using Common.Application;
using Common.Application.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Shop.Domain.UserAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.Edit
{
    public class EditUserCommand : IBaseCommand
    {
        public long UserId { get; private set; }
        public string UserName { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public Gender Gender { get; private set; }
        public IFormFile? Avatar { get; private set; }

        public EditUserCommand(string userName, string fullName, string email, string phoneNumber
            , Gender gender, IFormFile? avatar, long userId)
        {
            UserName = userName;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Gender = gender;
            Avatar = avatar;
            UserId = userId;
        }
    }
}