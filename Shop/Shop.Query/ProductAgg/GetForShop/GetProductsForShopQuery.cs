using Common.Query;
using Shop.Query.ProductAgg.DTOs;

namespace Shop.Query.ProductAgg.GetForShop
{
    public class GetProductsForShopQuery : QueryFilter<ProductShopResult, ProductShopFilterParams>
    {
        public GetProductsForShopQuery(ProductShopFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
