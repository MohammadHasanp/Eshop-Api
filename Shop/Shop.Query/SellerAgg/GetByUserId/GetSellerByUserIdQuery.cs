
using Common.Query;
using Shop.Query.SellerAgg.DTOs;

namespace Shop.Query.SellerAgg.GetByUserId
{
    public record GetSellerByUserIdQuery(long UserId):IQuery<SellerDto?>;
}
