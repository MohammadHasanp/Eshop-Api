using Common.Application;
using Common.Domain.Exceptions;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.IncreaseItemCount
{
    public class IncreaseOrderItemCountCommandHandler : IBaseCommandHandler<IncreaseOrderItemCountCommand>
    {
        private readonly IOrderRepository _repository;

        public IncreaseOrderItemCountCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(IncreaseOrderItemCountCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetCurrentUserOrder(request.userId);

            if (order == null)
                return OperationResult.NotFound();

            order.IncreaseCountItem(request.ItemId,request.count);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
