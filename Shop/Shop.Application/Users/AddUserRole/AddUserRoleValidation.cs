using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.AddUserRole
{
    public class AddUserRoleValidation : AbstractValidator<AddUserRoleCommand>
    {
        public AddUserRoleValidation()
        {
            RuleFor(u => u.Roles)
                .NotNull().WithMessage(ValidationMessages.Required)
                .NotEmpty().WithMessage(ValidationMessages.Required);
        }
    }
}
