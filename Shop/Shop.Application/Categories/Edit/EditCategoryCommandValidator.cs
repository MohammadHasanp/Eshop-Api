using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Categories.Edit
{
    public class EditCategoryCommandValidator : AbstractValidator<EditCategoryCommand>
    {
        public EditCategoryCommandValidator()
        {
            RuleFor(e=>e.Title).NotEmpty().NotNull().WithMessage(ValidationMessages.required("Title"));
           
            RuleFor(e=>e.Slug).NotEmpty().NotNull().WithMessage(ValidationMessages.required("Slug"));
        }
    }
}
