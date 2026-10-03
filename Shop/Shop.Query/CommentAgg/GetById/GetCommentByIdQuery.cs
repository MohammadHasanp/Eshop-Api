using Common.Query;
using Shop.Query.CommentAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.CommentAgg.GetById
{
    public class GetCommentByIdQuery:IQuery<CommentDto>
    {
        public long CommentId { get; private set; }
        public GetCommentByIdQuery(long commentId)
        {
            CommentId = commentId;
        }
    }
}
