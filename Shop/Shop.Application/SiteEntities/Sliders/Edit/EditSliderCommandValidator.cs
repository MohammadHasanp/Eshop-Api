using Common.Application.Validation.FluentValidations;
using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.SiteEntities.Sliders.Edit
{
    public class EditSliderCommandValidator : AbstractValidator<EditSliderCommand>
    {
        public EditSliderCommandValidator()
        {
            RuleFor(b => b.ImageFile)
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
