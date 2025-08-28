using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.SliderAgg.DTOs;
using Shop.Query.SliderAgg.Mapper;

namespace Shop.Query.SliderAgg.GetById
{
    public class GetSliderByIdHandler : IQueryHandler<GetSliderByIdQuery, SliderDto>
    {
        private readonly ShopContext _context;
        public GetSliderByIdHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<SliderDto> Handle(GetSliderByIdQuery request, CancellationToken cancellationToken)
        {
            var slider = await _context.Sliders.FirstOrDefaultAsync(s=>s.Id == request.SliderId,cancellationToken);
            
            if (slider == null)
                return null;

            return slider.Map();
        }
    }
}
