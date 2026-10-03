using FluentValidation;

namespace Shop.Application.Orders.AddItem
{
    public class AddOrderItemValidator : AbstractValidator<AddOrderItemCommand>
    {
        public AddOrderItemValidator()
        {
            RuleFor(o => o.Count)
                .GreaterThanOrEqualTo(1).WithMessage("The number must be greater than 0");
        }
    }
}