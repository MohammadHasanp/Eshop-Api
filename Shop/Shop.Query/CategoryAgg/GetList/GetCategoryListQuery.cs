using Common.Query;
using Shop.Query.CategoryAgg.DTOs;

namespace Shop.Query.CategoryAgg.GetList
{
    public record GetCategoryListQuery : IQuery<List<CategoryDto>>;
}
