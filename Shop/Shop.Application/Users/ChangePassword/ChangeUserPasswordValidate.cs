using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.ChangePassword
{
    public class ChangeUserPasswordValidate : AbstractValidator<ChangeUserPasswordCommand>
    {
        public ChangeUserPasswordValidate()
        {
            RuleFor(u => u.NewPassword)
                .NotNull().WithMessage(ValidationMessages.Required)
                .NotEmpty().WithMessage(ValidationMessages.Required)
                .MinimumLength(6).WithMessage(ValidationMessages.MinLength);

            RuleFor(u => u.CurrentPassword)
              .NotNull().WithMessage(ValidationMessages.Required)
              .NotEmpty().WithMessage(ValidationMessages.Required)
              .MinimumLength(6).WithMessage(ValidationMessages.MinLength);
        }
    }
}
