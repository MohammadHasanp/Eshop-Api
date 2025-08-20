using Common.Application;
using Shop.Domain.OrderAgg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Orders.RemoveItem
{
    public record RemoveOrderItemCommand(long itemId,long userId):IBaseCommand;
    public class RemoveOrderItemCommandHandler : IBaseCommandHandler<RemoveOrderItemCommand>
    {
        private readonly IOrderRepository _repository;

        public RemoveOrderItemCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(RemoveOrderItemCommand request, CancellationToken cancellationToken)
        {
            var item =await _repository.GetCurrentUserOrder(request.userId);

            if (item == null)
                return OperationResult.NotFound();

            item.DeleteItem(request.itemId);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
