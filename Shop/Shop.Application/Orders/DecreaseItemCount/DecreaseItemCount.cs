using Common.Application;
using Common.Domain.Exceptions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Orders.DecreaseItemCount
{
    public record DecreaseItemCount(long ItemID, long UserId, int Count) : IBaseCommand;

    public class DecreaseItemCountValidator : AbstractValidator<DecreaseItemCount>
    {
        public DecreaseItemCountValidator()
        {
            RuleFor(o => o.Count)
                .GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از 0 باشد");
        }
    }

}
