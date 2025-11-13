using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.ShippingMethod.Create
{
    public class CreateShippingMethodCommandValidator : AbstractValidator<CreateShippingMethodCommand>
    {
        public CreateShippingMethodCommandValidator()
        {
            RuleFor(s=>s.Title)
                .NotNull().WithMessage(ValidationMessages.Required)
                .NotEmpty().WithMessage(ValidationMessages.Required);
        }
    }
}
