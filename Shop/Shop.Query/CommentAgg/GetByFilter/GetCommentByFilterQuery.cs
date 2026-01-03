 using Common.Query;
using Shop.Query.CommentAgg.DTOs;

namespace Shop.Query.CommentAgg.GetByFilter
{
    public class GetCommentByFilterQuery : QueryFilter<CommentFilterResult, CommentFilterParams>
    {
        public GetCommentByFilterQuery(CommentFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
