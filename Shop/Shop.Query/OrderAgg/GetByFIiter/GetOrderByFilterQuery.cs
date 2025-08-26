using AngleSharp.Html;
using Common.Query;
using Shop.Query.OrderAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.OrderAgg.GetByFIiter
{
    public class GetOrderByFilterQuery : QueryFilter<OrderFilterResult, OrderFilterParams>
    {
        public GetOrderByFilterQuery(OrderFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
