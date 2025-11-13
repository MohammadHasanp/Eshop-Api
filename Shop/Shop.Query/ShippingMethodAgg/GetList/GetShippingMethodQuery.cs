using Common.Query;

namespace Shop.Query.ShippingMethodAgg.GetList
{
    public record GetShippingMethodQuery : IQuery<List<ShippingMethodDto>>;
}
