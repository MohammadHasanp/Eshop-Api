using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Orders.ChackoutOrderItem
{
    public class CheckoutOrderItemCommandHandler : IBaseCommandHandler<CheckoutOrderItemCommand>
    {
        private readonly IOrderRepository _repository;
        public CheckoutOrderItemCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CheckoutOrderItemCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetCurrentUserOrder(request.UserId);

            if (order == null)
                return OperationResult.NotFound();

            var address = new OrderAddress(request.Shire, request.City, request.PostalCode, request.PostalAddress, request.PhoneNumber
                , request.Name, request.Family, request.NationalCode);
            order.Checkout(address);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
