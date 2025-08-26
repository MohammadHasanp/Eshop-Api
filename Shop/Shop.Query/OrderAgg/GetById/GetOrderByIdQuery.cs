using Common.Query;
using Shop.Query.OrderAgg.DTOs;

namespace Shop.Query.OrderAgg.GetById
{
    public record GetOrderByIdQuery(long OrderId) : IQuery<OrderDto?>;
}
