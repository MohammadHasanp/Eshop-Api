using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.CommentAgg.DTOs;
using Shop.Query.CommentAgg.Mapper;

namespace Shop.Query.CommentAgg.GetById
{
    public class GetCommentByIdHandler : IQueryHandler<GetCommentByIdQuery, CommentDto>
    {
        private readonly ShopContext _context;
        public GetCommentByIdHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<CommentDto> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c=>c.Id == request.CommentId);
            if (comment == null)
                return null;
            return comment.Map();
        }
    }
}
