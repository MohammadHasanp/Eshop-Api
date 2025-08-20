using Common.Application.Validation.FluentValidations;
using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Products.Edit
{
    public class EditProductValidator : AbstractValidator<EditProductCommand>
    {
        public EditProductValidator()
        {
            RuleFor(p => p.Title)
                .NotNull()
                .NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

            RuleFor(p => p.Description)
                .NotNull()
                .NotEmpty().WithMessage(ValidationMessages.required("توضیحات"));

            RuleFor(p => p.Slug)
               .NotNull()
               .NotEmpty().WithMessage(ValidationMessages.required("Slug"));

            RuleFor(p => p.ImageFile)
                .JustImageFile();
        }
    }
}
