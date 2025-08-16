using Common.Application.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Categories.Create
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(c => c.title)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("Title"));
            RuleFor(c => c.slug)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("Slug"));
        }
    }
}
