using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.ShippingMethodAgg.Map;

namespace Shop.Query.ShippingMethodAgg.GetList
{
    public class GetShippingMethodQueryHandler : IQueryHandler<GetShippingMethodQuery, List<ShippingMethodDto>>
    {
        private readonly ShopContext _context;
        public GetShippingMethodQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<ShippingMethodDto>> Handle(GetShippingMethodQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.ShippingMothods.OrderByDescending(s => s.Id).ToListAsync();
            var model = result.MapList();
            return model;


        }
    }
}
