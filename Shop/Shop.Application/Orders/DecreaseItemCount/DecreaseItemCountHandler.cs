using Common.Application;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.DecreaseItemCount
{
    public class DecreaseItemCountHandler : IBaseCommandHandler<DecreaseItemCount>
    {
        private readonly IOrderRepository _repository;

        public DecreaseItemCountHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(DecreaseItemCount request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetCurrentUserOrder(request.UserId);

            if (order == null)
                return OperationResult.NotFound();

            order.DecCountItem(request.ItemID, request.Count);
            await _repository.Save();
            return OperationResult.Success();
        }
    }

}
