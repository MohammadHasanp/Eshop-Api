using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.BannerAgg.DTOs;
using Shop.Query.BannerAgg.Mapper;

namespace Shop.Query.BannerAgg.GetById
{
    public class GetBannerByIdHandler : IQueryHandler<GetBannerByIdQuery, BannerDto>
    {
        private readonly ShopContext _context;
        public GetBannerByIdHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<BannerDto> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
        {
            var banner = await _context.Banners.
                FirstOrDefaultAsync(b => b.Id == request.BannerId, cancellationToken);

            if (banner == null)
                return null;

            return banner.Map();

        }
    }
}
