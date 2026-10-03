using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;
using Shop.Domain.OrderAgg.ValueObjects;
using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repository;
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
        private readonly IShippingMethodRepository _shippingMethideRepository;
        public CheckoutOrderItemCommandHandler(IOrderRepository repository, IShippingMethodRepository shippingMethideRepository)
        {
            _repository = repository;
            _shippingMethideRepository = shippingMethideRepository;
        }

        public async Task<OperationResult> Handle(CheckoutOrderItemCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetCurrentUserOrder(request.UserId);

            if (order == null)
                return OperationResult.NotFound();

            var address = new OrderAddress(request.Shire, request.City, request.PostalCode, request.PostalAddress, request.PhoneNumber
                , request.Name, request.Family, request.NationalCode);

            var shippingMethod = await _shippingMethideRepository.GetAsync(request.ShippingMethodId);
            if (shippingMethod == null)
                return OperationResult.Error();

            order.Checkout(address,new OrderShippingMethod(shippingMethod.Title,shippingMethod.Cost));
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}