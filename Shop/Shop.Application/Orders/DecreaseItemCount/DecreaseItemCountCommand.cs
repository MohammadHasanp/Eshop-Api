using Common.Application;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Orders.DecreaseItemCount
{
    public record DecreaseItemCountCommand(long ItemID, long UserId, int Count) : IBaseCommand;

}
