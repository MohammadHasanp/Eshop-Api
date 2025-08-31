using Common.Application;
using Shop.Application.SiteEntities.Banners.Create;
using Shop.Application.SiteEntities.Banners.Edit;
using Shop.Query.BannerAgg.DTOs;

namespace Shop.Presentation.Facade.BannerAgg
{
    public interface IBannerFacade
    {
        Task<OperationResult>Create(CreateBannerCommand command);
        Task<OperationResult> Edit(EditBannerCommand command);


        Task<BannerDto> GetBannerById(long Id);
        Task<List<BannerDto>> GetAllBanner();
    }
}
