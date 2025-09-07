using Common.Query;
using Shop.Query.SellerAgg.DTOs;

namespace Shop.Query.SellerAgg.GetById
{
    public record GetSellerByIdQuery(long SellerId):IQuery<SellerDto?>;
}
