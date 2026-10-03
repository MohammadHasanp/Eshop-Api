using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.SliderAgg.DTOs;
using Shop.Query.SliderAgg.Mapper;

namespace Shop.Query.SliderAgg.GetList
{
    public class GetAllSliderHandler : IQueryHandler<GetAllSliderQurey, List<SliderDto>>
    {
        private readonly ShopContext _context;
        public GetAllSliderHandler(ShopContext context)
        {
            this._context = context;
        }
        public async Task<List<SliderDto>> Handle(GetAllSliderQurey request, CancellationToken cancellationToken)
        {
            var slider = await _context.Sliders.OrderByDescending(s => s.Id).ToListAsync(cancellationToken);
            return slider.MapList();
        }
    }
}
