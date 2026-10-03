using Common.Query;
using Shop.Query.ProductAgg.DTOs;

namespace Shop.Query.ProductAgg.GetBySlug
{
    public record GetProductBySlugQuery(string Slug):IQuery<ProductDto>;
}
