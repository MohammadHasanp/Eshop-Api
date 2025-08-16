using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Categories.AddChild
{
    public class AddChildCategoryValidator : AbstractValidator<AddChildCategoryCommand>
    {
        public AddChildCategoryValidator()
        {
            RuleFor(a => a.Title).NotEmpty().NotNull().WithMessage(ValidationMessages.required("Title"));

            RuleFor(a=>a.Slug).NotEmpty().NotNull().WithMessage(ValidationMessages.required("Slug"));
        }
    }
}

