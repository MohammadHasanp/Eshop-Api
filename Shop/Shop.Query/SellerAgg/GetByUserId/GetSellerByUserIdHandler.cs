using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.SellerAgg.DTOs;
using Shop.Query.SellerAgg.Mapper;

namespace Shop.Query.SellerAgg.GetByUserId
{
    public class GetSellerByUserIdHandler : IQueryHandler<GetSellerByUserIdQuery, SellerDto?>
    {
        private readonly ShopContext _context;
        public GetSellerByUserIdHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<SellerDto?> Handle(GetSellerByUserIdQuery request, CancellationToken cancellationToken)
        {
            var seller = await _context.Sellers.FirstOrDefaultAsync(s=>s.UserId == request.UserId,cancellationToken);
            return seller.Map();
        }
    }
}
