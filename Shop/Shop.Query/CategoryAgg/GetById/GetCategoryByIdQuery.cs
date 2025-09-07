using Common.Query;
using Shop.Query.CategoryAgg.DTOs;

namespace Shop.Query.CategoryAgg.GetById
{
    public record GetCategoryByIdQuery(long categoryId):IQuery<CategoryDto>;
}
