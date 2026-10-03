using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Products.Create
{
    public class CreatePeoductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreatePeoductValidator()
        {
            RuleFor(p=>p.Title)
                .NotNull()
                .NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
            
            RuleFor(p=>p.Description)
                .NotNull()
                .NotEmpty().WithMessage(ValidationMessages.required("توضیحات"));

            RuleFor(p => p.Slug)
               .NotNull()
               .NotEmpty().WithMessage(ValidationMessages.required("Slug"));

            RuleFor(p=>p.ImageFile)
                .JustImageFile();
        }
    }
}
