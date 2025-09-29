using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repository;
using Shop.Infrastructure._Utilities;
using Shop.Infrastructure.Persistent.Ef._Context;

namespace Shop.Infrastructure.Persistent.Ef.SliderAgg
{
    public class SliderRepository:BaseRepository<Slider>,ISliderRepository
    {
        public SliderRepository(ShopContext Context):base(Context)
        {

        }

        public void Delete(Slider slider)
        {
             _context.Entry(slider).State = EntityState.Deleted;
        }
    }
}
