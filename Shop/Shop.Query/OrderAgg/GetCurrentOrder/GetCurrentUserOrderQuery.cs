using Common.Query;
using Shop.Query.OrderAgg.DTOs;

namespace Shop.Query.OrderAgg.GetCurrentOrder
{
    public record GetCurrentUserOrderQuery(long UserId) : IQuery<OrderDto>;
}
