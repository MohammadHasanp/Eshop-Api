using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.Register
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(u => u.Password)
                .NotNull().WithMessage(ValidationMessages.required("کلمه عبور"))
                .NotEmpty().WithMessage(ValidationMessages.required("کلمه عبور"))
                .ValidPhoneNumber();
        }
    }
}
