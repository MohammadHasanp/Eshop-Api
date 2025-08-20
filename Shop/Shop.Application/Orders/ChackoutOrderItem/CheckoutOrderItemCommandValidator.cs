using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Orders.ChackoutOrderItem
{
    public class CheckoutOrderItemCommandValidator : AbstractValidator<CheckoutOrderItemCommand>
    {
        public CheckoutOrderItemCommandValidator()
        {
            RuleFor(o => o.Shire)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("استان"));

            RuleFor(o=>o.City)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("شهر"));

            RuleFor(o=>o.PostalCode)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("کد پستس"));

            RuleFor(o => o.PostalAddress)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("ادرس پستی"));

            RuleFor(o => o.PhoneNumber)
                .NotNull()
                .NotEmpty().WithMessage(ValidationMessages.required("تلفن"))
                .MaximumLength(11).WithMessage("شماره مبایل نامعتبر است")
                .MinimumLength(11).WithMessage("شماره مبایل نامعتبر است");

            RuleFor(o => o.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("نام"));

            RuleFor(o => o.Family)
              .NotNull()
              .NotEmpty()
              .WithMessage(ValidationMessages.required("نام خوانوادگی"));

            RuleFor(o => o.NationalCode)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("کد ملی"))
                .ValidNationalCode();
        }
    }
}
