using Common.AspNetCore;
using Common.AspNetCore.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.Application.Orders.AddItem;
using Shop.Application.Orders.ChackoutOrderItem;
using Shop.Application.Orders.DecreaseItemCount;
using Shop.Application.Orders.DeleteItem;
using Shop.Application.Orders.IncreaseItemCount;
using Shop.Domain.OrderAgg.Enums;
using Shop.Domain.RoleAgg.Enums;
using Shop.Presentation.Facade.OrderAgg;
using Shop.Query.OrderAgg.DTOs;
using System.Runtime.InteropServices;

namespace Shop.Api.Controllersl
{
    //[Authorize]
    public class OrderController : ApiController
    {
        private readonly IOrderItemFacade _orderItemFacade;
        public OrderController(IOrderItemFacade orderItemFacade)
        {
            _orderItemFacade = orderItemFacade;
        }
        [PermissionChecker(Permission.Order_Management)]
        [HttpGet]
        public async Task<ApiResult<OrderFilterResult>> GetOrderbyFilter([FromQuery] OrderFilterParams @params)
        {
            var result = await _orderItemFacade.GetOrderByFilter(@params);
            return QueryResult(result);
        }

        [HttpGet("current/filter")]
        public async Task<ApiResult<OrderFilterResult>> GetUserOrdersByFilter(int pageId = 1, int take = 10,
            OrderStatus orderStatus = OrderStatus.None)
        
        {
            var result = await _orderItemFacade.GetOrderByFilter(new OrderFilterParams()
            {
                EndDate = null,
                PageId = pageId,
                Take = take,
                StartDate = null,
                Status = orderStatus,
                UserId = User.GetUserId(),
            });
            return QueryResult(result);
        }

        [HttpGet("current")]
        public async Task<ApiResult<OrderDto?>> GetCurrentOrder()
        {
            var result = await _orderItemFacade.GetCurrentUserOrder(User.GetUserId());
            return QueryResult(result);
        }
        [HttpGet("{Id}")]
        public async Task<ApiResult<OrderDto?>> GetOrderById(long Id)
        {
            var result = await _orderItemFacade.GetOrderById(Id);
            return QueryResult(result);
        }
        [HttpPost]
        public async Task<ApiResult> AddOrderItem(AddOrderItemCommand command)
        {
            var result = await _orderItemFacade.Add(command);
            return CommandResult(result);
        }
        [HttpPut("checkout")]
        public async Task<ApiResult> CheckoutOrderItem(CheckoutOrderItemCommand command)
        {
            var result = await _orderItemFacade.Ordercheckout(command);
            return CommandResult(result);
        }
        [HttpPut("OrderItem/IncreaseCount")]
        public async Task<ApiResult> InCreaseOrderItemCount(IncreaseOrderItemCountCommand command)
        {
            var result = await _orderItemFacade.IncreaseItemCount(command);
            return CommandResult(result);
        }
        [HttpPut("OrderItem/DecreaseCount")]
        public async Task<ApiResult> DeCreaseOrderItemCount(DecreaseItemCountCommand command)
        {
            var result = await _orderItemFacade.DecreaseItemCount(command);
            return CommandResult(result);
        }
        [HttpDelete("OrderItem/{itemId}")]
        public async Task<ApiResult> DeleteOrderItem(long itemId)
        {
            var result = await _orderItemFacade.Delete(User.GetUserId(), itemId);
            return CommandResult(result);
        }
    }
}