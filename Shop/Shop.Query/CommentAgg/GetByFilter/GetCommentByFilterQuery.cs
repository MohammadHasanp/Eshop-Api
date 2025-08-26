using Common.Query;
using Shop.Query.CommentAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.CommentAgg.GetByFilter
{
    public class GetCommentByFilterQuery : QueryFilter<CommentFilterResult, CommentFilterParams>
    {
        public GetCommentByFilterQuery(CommentFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
