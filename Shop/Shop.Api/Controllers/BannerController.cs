using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.Api.ViewModel.Banners;
using Shop.Application.SiteEntities.Banners.Create;
using Shop.Application.SiteEntities.Banners.Edit;
using Shop.Domain.RoleAgg.Enums;
using Shop.Presentation.Facade.BannerAgg;
using Shop.Query.BannerAgg.DTOs;

namespace Shop.Api.Controllers

{
    //[PermissionChecker(Permission.CRUD_Banner)]
    public class BannerController : ApiController
    {
        private readonly IBannerFacade _bannerFacade;
        public BannerController(IBannerFacade bannerFacade)
        {
            _bannerFacade = bannerFacade;
        }
        [AllowAnonymous]
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
        public async Task<ApiResult> CreateBanner(CreateBannerViewModel viewModel)
        {
            var model = new CreateBannerCommand(viewModel.Link,viewModel.ImageFile,viewModel.Position);
            var result = await _bannerFacade.Create(model);
            return CommandResult(result);
        }
        [HttpPut]
        public async Task<ApiResult> EditBanner(EditBannerViewModel viewModel)
        {
            var model = new EditBannerCommand(viewModel.Link,viewModel.ImageFile,viewModel.Position,viewModel.BannerId);
            var result = await _bannerFacade.Edit(model);
            return CommandResult(result);
        }
        [HttpDelete("{BannerId}")]
        public async Task<ApiResult> DeleteBanner(long BannerId)
        {
            var result = await _bannerFacade.Delete(BannerId);
            return CommandResult(result);
        }
    }
}
