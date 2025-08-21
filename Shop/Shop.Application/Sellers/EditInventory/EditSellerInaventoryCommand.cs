using Common.Application;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SellerAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Sellers.EditInventory
{
    public class EditSellerInaventoryCommand : IBaseCommand
    {
        public long InventoryId { get; private set; }
        public long SellerId { get; private set; }
        public int Price { get; private set; }
        public int Count { get; private set; }
        public int? PercentageDiscount { get; private set; }

        public EditSellerInaventoryCommand(long sellerId, long inventoryId, long productId, int price, int count, int? percentageDiscount)
        {
            InventoryId = inventoryId;
            SellerId = sellerId;
            Price = price;
            Count = count;
            PercentageDiscount = percentageDiscount;
        }
    }

    public class EditSellerInventoryCommandHandler : IBaseCommandHandler<EditSellerInaventoryCommand>
    {
        private readonly ISellerRepository _repository;

        public EditSellerInventoryCommandHandler(ISellerRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(EditSellerInaventoryCommand request, CancellationToken cancellationToken)
        {
            var seller = await _repository.GetTracking(request.SellerId);

            if (seller == null)
                return OperationResult.NotFound();
            seller.EditInventory(request.InventoryId, request.Count, request.Price, request.PercentageDiscount);
            await _repository.Save();
            return OperationResult.Success();

        }
    }
}
