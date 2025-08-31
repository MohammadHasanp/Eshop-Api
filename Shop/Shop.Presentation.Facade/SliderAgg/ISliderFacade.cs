using Common.Application;
using Shop.Application.SiteEntities.Sliders.Create;
using Shop.Application.SiteEntities.Sliders.Edit;
using Shop.Query.SliderAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.SliderAgg
{
    public interface ISliderFacade
    {
        Task<OperationResult> Create(CreateSliderCommand command);
        Task<OperationResult> Edit(EditSliderCommand command);



        Task<SliderDto> GetSliderById(long Id);
        Task<List<SliderDto>> GetAllSlider();
    }
}
