using Shop.Domain.SiteEntities;

namespace Shop.Query.ShippingMethodAgg.Map
{
    public static class ShippingMethodMapper
    {
        public static List<ShippingMethodDto> MapList(this List<ShippingMothod> shipping)
        {
            var shippingMethods = new List<ShippingMethodDto>();

            shipping.ForEach(s =>
            {
                shippingMethods.Add(new ShippingMethodDto()
                {
                    Cost = s.Cost,
                    CreationDate = s.CreationDate,
                    Id = s.Id,
                    Title = s.Title,
                });
            });
            return shippingMethods;

        }


        public static ShippingMethodDto Map(this ShippingMothod shipping)
        {
            return new ShippingMethodDto()
            {
                Id = shipping.Id,
                Cost = shipping.Cost,
                CreationDate = shipping.CreationDate, 
                Title = shipping.Title,
            };
        }
    }
}
