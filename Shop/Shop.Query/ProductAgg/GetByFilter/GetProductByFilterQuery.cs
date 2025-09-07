using Common.Query;
using Shop.Query.ProductAgg.DTOs;

namespace Shop.Query.ProductAgg.GetByFilter
{
    public class GetProductByFilterQuery : QueryFilter<ProductFilterResult, ProductFilterParams>
    {
        public GetProductByFilterQuery(ProductFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
