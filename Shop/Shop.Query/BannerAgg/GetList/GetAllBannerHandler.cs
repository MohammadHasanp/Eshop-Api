using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.BannerAgg.DTOs;
using Shop.Query.BannerAgg.Mapper;

namespace Shop.Query.BannerAgg.GetList
{
    public class GetAllBannerHandler : IQueryHandler<GetAllBannerQuery, List<BannerDto>>
    {
        private readonly ShopContext _context;
        public GetAllBannerHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<List<BannerDto>> Handle(GetAllBannerQuery request, CancellationToken cancellationToken)
        {
            var banners = await _context.Banners.OrderByDescending(b => b.Id).ToListAsync(cancellationToken);
            var model = banners.MapList();
            return model;
        }
    }
}
