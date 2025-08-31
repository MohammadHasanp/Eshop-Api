using Common.Application;
using MediatR;
using Shop.Application.Orders.AddItem;
using Shop.Application.Orders.DecreaseItemCount;
using Shop.Application.Orders.DeleteItem;
using Shop.Application.Orders.IncreaseItemCount;
using Shop.Query.OrderAgg.DTOs;
using Shop.Query.OrderAgg.GetByFIiter;
using Shop.Query.OrderAgg.GetById;

namespace Shop.Presentation.Facade.OrderAgg
{
    public class OrderFacade : IOrderItemFacade
    {
        private readonly IMediator _mediator;
        public OrderFacade(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<OperationResult> Add(AddOrderItemCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DecreaseItemCount(DecreaseItemCountCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Delete(DeleteOrderItemCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OrderFilterResult> GetOrderByFilter(OrderFilterParams @params)
        {
            return await _mediator.Send(new GetOrderByFilterQuery(@params));
        }

        public async Task<OrderDto?> GetOrderById(long Id)
        {
            return await _mediator.Send(new GetOrderByIdQuery(Id));
        }

        public async Task<OperationResult> IncreaseItemCount(IncreaseOrderItemCountCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
