using Common.Query;
using Shop.Query.SellerAgg.DTOs;

namespace Shop.Query.SellerAgg.Inventory.GetById
{
    public record GetSellerInventoryByIdQuery(long Id):IQuery<SellerInventoryDto?>;
}
