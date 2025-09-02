using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.SiteEntities.Banners.Create;
using Shop.Application.SiteEntities.Banners.Edit;
using Shop.Presentation.Facade.BannerAgg;
using Shop.Query.BannerAgg.DTOs;

namespace Shop.Api.Controllers
{
    public class BannerController : ApiController
    {
        private readonly IBannerFacade _bannerFacade;
        public BannerController(IBannerFacade bannerFacade)
        {
            _bannerFacade = bannerFacade;
        }
        [HttpGet]
        public async Task<ApiResult<List<BannerDto>>> GetAllBanner()
        {
            var result = await _bannerFacade.GetAllBanner();
            return QueryResult(result);
        }
        [HttpGet("{Id}")]
        public async Task<ApiResult<BannerDto>>GetBannerById(long Id)
        {
            var result = await _bannerFacade.GetBannerById(Id);
            return QueryResult(result);
        }
        [HttpPost]
        public async Task<ApiResult> CreateBanner(CreateBannerCommand command)
        {
            var result = await _bannerFacade.Create(command);
            return CommandResult(result);
        }
        [HttpPut]
        public async Task<ApiResult> EditBanner(EditBannerCommand command)
        {
            var result = await _bannerFacade.Edit(command);
            return CommandResult(result);
        }
    }
}
