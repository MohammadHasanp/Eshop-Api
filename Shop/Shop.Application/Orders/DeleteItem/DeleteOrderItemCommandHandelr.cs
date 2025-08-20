using Common.Application;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.DeleteItem
{
    public class DeleteOrderItemCommandHandelr : IBaseCommandHandler<DeleteOrderItemCommand>
    {
        private readonly IOrderRepository _repository;
        public DeleteOrderItemCommandHandelr(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetCurrentUserOrder(request.UserId);

            if (order == null)
                return OperationResult.NotFound();

            order.DeleteItem(request.ItemId);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
