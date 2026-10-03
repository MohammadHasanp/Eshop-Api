using Common.Query;
using Shop.Query.SellerAgg.DTOs;

namespace Shop.Query.SellerAgg.Inventory.GetList
{
    public record GetAllSellerInventoryBySellerIdQuery(long SellerId):IQuery<List<SellerInventoryDto>>;
}
