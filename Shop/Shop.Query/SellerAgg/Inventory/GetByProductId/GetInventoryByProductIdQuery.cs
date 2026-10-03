using Common.Query;
using Shop.Query.SellerAgg.DTOs;

namespace Shop.Query.SellerAgg.Inventory.GetByProductId
{
    public record GetInventoryByProductIdQuery(long ProductId):IQuery<List<SellerInventoryDto>>;
}
