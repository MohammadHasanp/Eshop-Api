using Common.Application;
using MediatR;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.Finally
{
    public record OrderFinallyCommand(long OrderId):IBaseCommand;



    public class OrderFinallyCommandHandler : IBaseCommandHandler<OrderFinallyCommand>
    {
        private readonly IOrderRepository _repository;
        private IMediator _mediator;
        public OrderFinallyCommandHandler(IOrderRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<OperationResult> Handle(OrderFinallyCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetTracking(request.OrderId);
            if (order == null)
                return OperationResult.NotFound();

            order.Finally();
            await _repository.Save();
            foreach (var item in order.BaseDomains)
            {
                await _mediator.Publish(item,cancellationToken);
            }
            return OperationResult.Success();
        }
    }
}
