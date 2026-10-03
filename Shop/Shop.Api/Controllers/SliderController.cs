using Common.Application;
using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.Api.ViewModel.Slider;
using Shop.Application.SiteEntities.Sliders.Create;
using Shop.Application.SiteEntities.Sliders.Edit;
using Shop.Domain.RoleAgg.Enums;
using Shop.Presentation.Facade.SliderAgg;
using Shop.Query.SliderAgg.DTOs;

namespace Shop.Api.Controllers
{
    //[PermissionChecker(Permission.CRUD_Slider)]
    public class SliderController : ApiController
    {
        private readonly ISliderFacade _sliderFacade;
        public SliderController(ISliderFacade sliderFacade)
        {
            _sliderFacade = sliderFacade;
        }
        [AllowAnonymous]
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
        public async Task<ApiResult> CreateSlider(CreateSliderViewModel viewModel)
        {
            var model = new CreateSliderCommand(viewModel.Title,viewModel.Link,viewModel.ImageFile);
            var result = await _sliderFacade.Create(model);
            return CommandResult(result);
        }
        [HttpPut]
        public async Task<ApiResult> EditSlider(EditSliderViewModel viewModel)
        {
            var model = new EditSliderCommand(viewModel.SliderId, viewModel.Title, viewModel.Link, viewModel.ImageFile);
            var result = await _sliderFacade.Edit(model);
            return CommandResult(result);
        }

        [HttpDelete("{sliderId}")]
        public async Task<ApiResult> DeleteSlider(long sliderId)
        {
            var result =await _sliderFacade.Delete(sliderId);
            return CommandResult(result);
        }
    }
}
