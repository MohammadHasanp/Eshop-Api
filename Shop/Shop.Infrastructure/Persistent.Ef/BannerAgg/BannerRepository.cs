using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repository;
using Shop.Infrastructure._Utilities;
using Shop.Infrastructure.Persistent.Ef._Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.BannerAgg
{
    public class BannerRepository:BaseRepository<Banner>,IBannerRepository
    {
        public BannerRepository(ShopContext context):base(context)
        {

        }
    }
}
