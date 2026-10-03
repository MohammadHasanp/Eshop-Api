using Common.Query;
using Shop.Query.OrderAgg.DTOs;

namespace Shop.Query.OrderAgg.GetByFIiter
{
    public class GetOrderByFilterQuery : QueryFilter<OrderFilterResult, OrderFilterParams>
    {
        public GetOrderByFilterQuery(OrderFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
