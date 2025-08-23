using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.Edit
{
    public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
    {
        public EditUserCommandValidator()
        {
            RuleFor(u => u.Email)
               .EmailAddress().WithMessage("ایمیل نامعتبر است");

            RuleFor(u => u.Password)
                .MinimumLength(4).WithMessage("کلمه عیور باید بیشتر از 4 کاراکتر باشد");

            RuleFor(u => u.PhoneNumber)
                .ValidPhoneNumber();

            RuleFor(u => u.Avatar)
                .JustImageFile();
        }
    }
}