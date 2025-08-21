using Common.Application;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Sellers.AddInventory
{
    public class AddSellerInventoryCommandHandler : IBaseCommandHandler<AddSellerInventoryCommand>
    {
        ISellerRepository _repository;

        public AddSellerInventoryCommandHandler(ISellerRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(AddSellerInventoryCommand request, CancellationToken cancellationToken)
        {
            var seller = await _repository.GetTracking(request.SellerId);

            if (seller == null)
                return OperationResult.NotFound();

            var sellerInventory = new SellerInventory(request.ProductId,request.Price,request.Count
                ,request.PercentageDiscount);
            seller.AddInventory(sellerInventory);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
