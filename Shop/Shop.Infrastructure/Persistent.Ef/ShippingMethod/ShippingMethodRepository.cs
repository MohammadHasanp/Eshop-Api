using Common.Domain.Repository;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repository;
using Shop.Infrastructure._Utilities;
using Shop.Infrastructure.Persistent.Ef._Context;

namespace Shop.Infrastructure.Persistent.Ef.ShippingMethod
{
    public class ShippingMethodRepository : BaseRepository<ShippingMothod>, IShippingMethodRepository
    {
        public ShippingMethodRepository(ShopContext context):base(context)
        {
        }

        public void Delete(ShippingMothod shipping)
        {
            _context.Entry(shipping).State = EntityState.Deleted;
        }
    }
}
