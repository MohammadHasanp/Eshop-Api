using Microsoft.EntityFrameworkCore;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Repository;
using Shop.Infrastructure._Utilities;
using Shop.Infrastructure.Persistent.Ef._Context;

namespace Shop.Infrastructure.Persistent.Ef.RoleAgg
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(ShopContext context) : base(context)
        {
        }

        public void Delete(Role role)
        {
            _context.Entry(role).State = EntityState.Deleted; 
        }
    }
}
