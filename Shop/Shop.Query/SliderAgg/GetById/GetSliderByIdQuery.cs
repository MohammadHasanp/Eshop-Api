using Common.Query;
using Shop.Query.SliderAgg.DTOs;

namespace Shop.Query.SliderAgg.GetById
{
    public record GetSliderByIdQuery(long SliderId):IQuery<SliderDto>;
}
