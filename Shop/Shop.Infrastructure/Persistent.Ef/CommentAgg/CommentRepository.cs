using Shop.Domain.CommentAgg;
using Shop.Domain.CommentAgg.Repository;
using Shop.Infrastructure._Utilities;
using Shop.Infrastructure.Persistent.Ef._Context;

namespace Shop.Infrastructure.Persistent.Ef.CommentAgg
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ShopContext context) : base(context)
        {
        }
    }
}
