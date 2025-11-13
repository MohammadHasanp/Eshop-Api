using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.ShippingMethodAgg.Map;

namespace Shop.Query.ShippingMethodAgg.GetById
{
    public class GetShippingMethodByIdQuery : IQueryHandler<GetShippingMethoByIdQuery, ShippingMethodDto>
    {
        private readonly ShopContext _context;
        public GetShippingMethodByIdQuery(ShopContext context)
        {
            _context = context;
        }

        public async Task<ShippingMethodDto> Handle(GetShippingMethoByIdQuery request, CancellationToken cancellationToken)
        {
            var shipping = await _context.ShippingMothods.FirstOrDefaultAsync(s => s.Id == request.Id);
            if (shipping == null)
                return null;

            return shipping.Map();
        }
    }
}
