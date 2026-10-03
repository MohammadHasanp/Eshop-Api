using FluentValidation;

namespace Shop.Application.Sellers.EditInventory
{
    public class EditSellerInventoryCommandValidator : AbstractValidator<EditSellerInaventoryCommand>
    {
        public EditSellerInventoryCommandValidator()
        {
            RuleFor(s => s.Count)
               .GreaterThanOrEqualTo(1).WithMessage("تعداد محصول وارد شده باید بیشتر از 0 باشد");

            RuleFor(s => s.Price)
                .GreaterThanOrEqualTo(1000).WithMessage("قیمت محصول وارد شده باید بیشتر از 1,0000 تومان باشد");
        }
    }
}
