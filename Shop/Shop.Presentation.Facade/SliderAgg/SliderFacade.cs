using Common.Application;
using MediatR;
using Shop.Application.SiteEntities.Sliders.Create;
using Shop.Application.SiteEntities.Sliders.Edit;
using Shop.Query.SliderAgg.DTOs;
using Shop.Query.SliderAgg.GetById;
using Shop.Query.SliderAgg.GetList;

namespace Shop.Presentation.Facade.SliderAgg
{
    public class SliderFacade : ISliderFacade
    {
        private readonly IMediator _mediator;

        public SliderFacade(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<OperationResult> Create(CreateSliderCommand command)
        {
            return await _mediator.Send(command);
        }
        public async Task<OperationResult> Edit(EditSliderCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<List<SliderDto>> GetAllSlider()
        {
            return await _mediator.Send(new GetAllSliderQurey());
        }

        public async Task<SliderDto> GetSliderById(long Id)
        {
            return await _mediator.Send(new GetSliderByIdQuery(Id));
        }
    }
}
