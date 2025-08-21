using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.SiteEntities.Banners.Edit
{
    public class EditBannerCommandValidator : AbstractValidator<EditBannerCommand>
    {
        public EditBannerCommandValidator()
        {
            RuleFor(b => b.ImageFile)
                .JustValidFile();

            RuleFor(b => b.Link)
                .NotNull()
                .NotEmpty().WithMessage(ValidationMessages.required("لینک"));
        }
    }
}
