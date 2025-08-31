using FluentValidation;

namespace Shop.Application.Orders.DecreaseItemCount
{
    public class DecreaseItemCountValidator : AbstractValidator<DecreaseItemCountCommand>
    {
        public DecreaseItemCountValidator()
        {
            RuleFor(o => o.Count)
                .GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از 0 باشد");
        }
    }

}
