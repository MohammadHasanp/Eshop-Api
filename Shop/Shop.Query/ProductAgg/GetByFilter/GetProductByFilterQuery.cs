using Common.Query;
using Shop.Query.ProductAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.ProductAgg.GetByFilter
{
    public class GetProductByFilterQuery : QueryFilter<ProductFilterResult, ProductFilterParams>
    {
        public GetProductByFilterQuery(ProductFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
