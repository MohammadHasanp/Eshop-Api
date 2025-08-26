using Common.Query;
using Common.Query.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shop.Domain.CommentAgg.Comment;

namespace Shop.Query.CommentAgg.DTOs
{
    public class CommentDto:BaseDto
    {
        public long UserId { get; set; }
        public long ProductId{ get; set; }
        public string UserFullName { get; set; }
        public string ProductTitle { get; set; }
        public CommentStatus Status{ get; set; }
        public string Text { get; set; }
    }
    public class CommentFilterParams:BaseFilterParam
    {
        public long? UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate{ get; set; }
        public CommentStatus? Status { get; set; }
    }
    public class CommentFilterResult : BaseFilter<CommentDto, CommentFilterParams> { }
}
