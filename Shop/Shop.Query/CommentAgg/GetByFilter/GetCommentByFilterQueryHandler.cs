using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.CommentAgg.DTOs;
using Shop.Query.CommentAgg.Mapper;

namespace Shop.Query.CommentAgg.GetByFilter
{
    public class GetCommentByFilterQueryHandler : IQueryHandler<GetCommentByFilterQuery, CommentFilterResult>
    {
        private readonly ShopContext _context;
        public GetCommentByFilterQueryHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<CommentFilterResult> Handle(GetCommentByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var result = _context.Comments.OrderByDescending(c => c.CreationDate).AsQueryable();

            if (@params.ProductId != null)
                result = result.Where(c=>c.ProductId == @params.ProductId);

            if(@params.UserId != null)
            {
                result = result.Where(c=>c.UserId==@params.UserId);
            }
            if (@params.StartDate != null)
            {
                result = result.Where(c => c.CreationDate.Date >= @params.StartDate.Value.Date);
            }
            if (@params.EndDate != null)
            {
                result = result.Where(c => c.CreationDate <= @params.EndDate.Value.Date);
            }
            if (@params.Status != null)
            {
                result = result.Where(c => c.Status == @params.Status);
            }
            var skip = (@params.PageId - 1) * @params.Take;

            var model = new CommentFilterResult()
            {
                Datas = await result.Skip(skip).Take(@params.Take).Select(comment => comment.Map())
                .ToListAsync(cancellationToken),
                FilterParams = @params
            };
            model.GeneratePaging(result,@params.Take,@params.PageId);
            return model;
        }
    }
}
