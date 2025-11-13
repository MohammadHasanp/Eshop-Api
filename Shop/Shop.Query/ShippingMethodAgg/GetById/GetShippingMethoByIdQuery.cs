using Common.Query;

namespace Shop.Query.ShippingMethodAgg.GetById
{
    public record GetShippingMethoByIdQuery(long Id) : IQuery<ShippingMethodDto>;
}
