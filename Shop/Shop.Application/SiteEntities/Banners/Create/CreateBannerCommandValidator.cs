using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;
using Shop.Application.Categories.Create;

namespace Shop.Application.SiteEntities.Banners.Create
{
    public class CreateBannerCommandValidator : AbstractValidator<CreateBannerCommand>
    {
        public CreateBannerCommandValidator()
        {
            RuleFor(b=>b.ImageFile)
                .NotNull().WithMessage("لطفا بخش تصویر را کامل کنید")
                .JustValidFile();

            RuleFor(b=>b.Link)
                .NotNull()
                .NotEmpty().WithMessage(ValidationMessages.required("لینک"));
        }
    }
}
