using Common.Application;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Orders.DeleteItem
{
    public record DeleteOrderItemCommand(long UserId,long ItemId) : IBaseCommand;
}
