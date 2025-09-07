using Common.Query;
using Shop.Query.ProductAgg.DTOs;

namespace Shop.Query.ProductAgg.GetById
{
    public record GetProductByIdQuery(long ProductId) : IQuery<ProductDto>;
}
