using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Sellers.Edit
{
    public class EditSellerCommandValidator : AbstractValidator<EditSellerCommand>
    {
        public EditSellerCommandValidator()
        {
            RuleFor(s => s.ShopName)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("نام فروشگاه"));

            RuleFor(s => s.NationalCode)
                .NotNull()
                .NotEmpty().WithMessage(ValidationMessages.required("کد ملی"))
                .ValidNationalCode();
        }
    }
}
