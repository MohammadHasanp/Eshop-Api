using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.SellerAgg.DTOs;
using Shop.Query.SellerAgg.Mapper;

namespace Shop.Query.SellerAgg.GetById
{
    public class GetSellerByIdHandler : IQueryHandler<GetSellerByIdQuery, SellerDto>
    {
        private readonly ShopContext _context;
        public GetSellerByIdHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<SellerDto> Handle(GetSellerByIdQuery request, CancellationToken cancellationToken)
        {
            var seller = await _context.Sellers.FirstOrDefaultAsync(s=>s.Id == request.SellerId);

            if (seller == null)
                return null;

            return seller.Map();
        }
    }
}
