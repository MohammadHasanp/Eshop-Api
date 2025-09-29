using Microsoft.EntityFrameworkCore;
using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repository;
using Shop.Infrastructure._Utilities;
using Shop.Infrastructure.Persistent.Ef._Context;

namespace Shop.Infrastructure.Persistent.Ef.BannerAgg
{
    public class BannerRepository:BaseRepository<Banner>,IBannerRepository
    {
        public BannerRepository(ShopContext context):base(context)
        {

        }

        public void Delete(Banner banner)
        {
            _context.Entry(banner).State = EntityState.Deleted; 
        }
    }
}
