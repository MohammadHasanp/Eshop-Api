using Common.Query;
using Shop.Query.SliderAgg.DTOs;

namespace Shop.Query.SliderAgg.GetList
{
    public record GetAllSliderQurey():IQuery<List<SliderDto>>;
}
