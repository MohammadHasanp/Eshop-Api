
using Common.Application;
using MediatR;

namespace Shop.Application.SiteEntities.Sliders.Delete
{
    public record DeleteSliderCommand(long SliderId) : IBaseCommand;
}
