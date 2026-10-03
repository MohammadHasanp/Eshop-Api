
using Common.Domain.Repository;

namespace Shop.Domain.SiteEntities.Repository
{
    public interface IShippingMethodRepository:IBaseRepository<ShippingMothod>
    {
        public void Delete(ShippingMothod shipping);
    }
}
