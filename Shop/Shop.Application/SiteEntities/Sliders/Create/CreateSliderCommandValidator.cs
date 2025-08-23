using Common.Application.Validation.FluentValidations;
using Common.Application.Validation;
using FluentValidation;
using Shop.Application.SiteEntities.Banners.Create;

namespace Shop.Application.SiteEntities.Sliders.Create
{
    public class CreateSliderCommandValidator : AbstractValidator<CreateSliderCommand>
    {
        public CreateSliderCommandValidator()
        {
            RuleFor(b => b.ImageFile)
                .NotNull().WithMessage("لطفا بخش تصویر را کامل کنید")
                .JustValidFile();

            RuleFor(b => b.Link)
                .NotNull()
                .NotEmpty().WithMessage(ValidationMessages.required("لینک"));

            RuleFor(b => b.Title)
               .NotNull()
               .NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
        }
    }
}