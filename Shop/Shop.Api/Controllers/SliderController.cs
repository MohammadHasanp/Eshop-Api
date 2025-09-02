using Common.Application;
using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.SiteEntities.Sliders.Create;
using Shop.Application.SiteEntities.Sliders.Edit;
using Shop.Presentation.Facade.SliderAgg;
using Shop.Query.SliderAgg.DTOs;

namespace Shop.Api.Controllers
{
    public class SliderController : ApiController
    {
        private readonly ISliderFacade _sliderFacade;
        public SliderController(ISliderFacade sliderFacade)
        {
            _sliderFacade = sliderFacade;
        }
        [HttpGet]
        public async Task<ApiResult<List<SliderDto>>> GetAllSlider()
        {
            var result = await _sliderFacade.GetAllSlider();
            return QueryResult(result);
        }
        [HttpGet("{Id}")]
        public async Task<ApiResult<SliderDto>> GetsliderById(long Id)
        {
            var result = await _sliderFacade.GetSliderById(Id);
            return QueryResult(result);
        }
        [HttpPost]
        public async Task<ApiResult> CreateSlider(CreateSliderCommand command)
        {
            var result = await _sliderFacade.Create(command);
            return CommandResult(result);
        }
        [HttpPut]
        public async Task<ApiResult> EditSlider(EditSliderCommand command)
        {
            var result = await _sliderFacade.Edit(command);
            return CommandResult(result);
        }

    }
}
