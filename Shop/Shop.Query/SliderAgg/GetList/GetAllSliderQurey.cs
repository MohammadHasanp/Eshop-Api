using Common.Query;
using Shop.Query.SliderAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.SliderAgg.GetList
{
    public record GetAllSliderQurey():IQuery<List<SliderDto>>;
}
