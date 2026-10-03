using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Products.AddImage
{
    public class AddProductImageValidator : AbstractValidator<AddProductImageCommand>
    {
        public AddProductImageValidator()
        {
            RuleFor(p => p.ImageFile)
                .NotNull().WithMessage(ValidationMessages.required("تصویر"))
                .JustImageFile();

            RuleFor(p=>p.Sequence)
                .GreaterThanOrEqualTo(0).WithMessage("شماره ترتیب عکس باید عددی بیشتر از 0 باشد");
        }
    }
}
