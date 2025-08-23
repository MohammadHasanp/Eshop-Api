using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.Create
{
    public class CreateUserCommandValidaotr : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidaotr()
        {
            RuleFor(u => u.Email)
                .EmailAddress().WithMessage("ایمیل نامعتبر است")
                .NotEmpty().WithMessage(ValidationMessages.required("ایمیل"))
                .NotNull().WithMessage(ValidationMessages.required("ایمیل"));

            RuleFor(u => u.Password)
                .NotNull().WithMessage(ValidationMessages.required("کلمه عبور"))
                .NotEmpty().WithMessage(ValidationMessages.required("کلمه عبور"))
                .MinimumLength(4).WithMessage("کلمه عیور باید بیشتر از 4 کاراکتر باشد");

            RuleFor(u => u.PhoneNumber)
                .NotNull().WithMessage(ValidationMessages.required("تلفن"))
                .NotEmpty().WithMessage(ValidationMessages.required("تلفن"))
                .Length(11)
                .ValidPhoneNumber();
        }
    }
}
