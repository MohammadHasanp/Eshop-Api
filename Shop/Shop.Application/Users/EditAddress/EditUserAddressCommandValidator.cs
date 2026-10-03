using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.EditAddress
{
    public class EditUserAddressCommandValidator : AbstractValidator<EditUserAddressCommand>
    {
        public EditUserAddressCommandValidator()
        {
            RuleFor(a => a.Shire)
                .NotNull().WithMessage(ValidationMessages.required("استان"))
                .NotEmpty().WithMessage(ValidationMessages.required("استان"));

            RuleFor(a => a.City)
                .NotNull().WithMessage(ValidationMessages.required("شهر"))
                .NotEmpty().WithMessage(ValidationMessages.required("شهر"));

            RuleFor(a => a.PostalCode)
                .NotNull().WithMessage(ValidationMessages.required("کد پستی"))
                .NotEmpty().WithMessage(ValidationMessages.required("کد پستی"))
                .Length(10).WithMessage("کد پستی باید 10 کاراکتر باشد");

            RuleFor(a => a.PostalAddress)
                .NotNull().WithMessage(ValidationMessages.required("ادرس پستی"))
                .NotEmpty().WithMessage(ValidationMessages.required("ادرس پستی"));

            RuleFor(a => a.PhoneNumber)
                .NotNull().WithMessage(ValidationMessages.required("تلفن"))
                .NotEmpty().WithMessage(ValidationMessages.required("تلفن"));

            RuleFor(a => a.PhoneNumber)
                .NotNull().WithMessage(ValidationMessages.required("نام"))
                .NotEmpty().WithMessage(ValidationMessages.required("تام"));

            RuleFor(a => a.Name)
                .NotNull().WithMessage(ValidationMessages.required("نام"))
                .NotEmpty().WithMessage(ValidationMessages.required("نام"));

            RuleFor(a => a.Family)
                .NotNull().WithMessage(ValidationMessages.required("نام خوانوادگی"))
                .NotEmpty().WithMessage(ValidationMessages.required(" نام خوانوادگی"));

            RuleFor(a => a.NationalCode)
                .NotNull().WithMessage(ValidationMessages.required("ایمیل"))
                .NotEmpty().WithMessage(ValidationMessages.required("ایمیل"))
                .ValidNationalCode();
        }
    }
}
