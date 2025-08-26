using Common.Domain.Repository;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using Shop.Infrastructure._Utilities;
using Shop.Infrastructure.Persistent.Ef._Context;

namespace Shop.Infrastructure.Persistent.Ef.UserAgg
{
    public class UserRepository:BaseRepository<User>, IUserRepository
    {
        public UserRepository(ShopContext Context):base(Context)
        {

        }
    }
}
