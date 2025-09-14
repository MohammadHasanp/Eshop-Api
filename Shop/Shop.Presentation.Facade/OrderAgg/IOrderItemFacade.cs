using Common.Application;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Shop.Application.Orders.AddItem;
using Shop.Application.Orders.ChackoutOrderItem;
using Shop.Application.Orders.DecreaseItemCount;
using Shop.Application.Orders.DeleteItem;
using Shop.Application.Orders.IncreaseItemCount;
using Shop.Application.Users.Register;
using Shop.Query.OrderAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.OrderAgg
{
    public interface IOrderItemFacade
    {
        Task<OperationResult>Add(AddOrderItemCommand command);
        Task<OperationResult> DecreaseItemCount(DecreaseItemCountCommand command);
        Task<OperationResult> IncreaseItemCount(IncreaseOrderItemCountCommand command);
        Task<OperationResult> Delete(long UserId, long ItemId);
        Task<OperationResult> Ordercheckout(CheckoutOrderItemCommand command);

        Task<OrderDto?> GetOrderById(long Id);
        Task<OrderFilterResult> GetOrderByFilter(OrderFilterParams @params);
        Task<OrderDto?> GetCurrentUserOrder(long CurrentId);
    }
}
