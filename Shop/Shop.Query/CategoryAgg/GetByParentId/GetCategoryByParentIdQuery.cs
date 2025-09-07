using Common.Query;
using Shop.Query.CategoryAgg.DTOs;

namespace Shop.Query.CategoryAgg.GetByParentId
{
    public record GetCategoryByParentIdQuery(int ParentId):IQuery<List<SubCategoryDto>>;
}
