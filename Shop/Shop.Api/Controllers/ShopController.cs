using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModel.Shop;
using Shop.Presentation.Facade.BannerAgg;
using Shop.Presentation.Facade.ProductAgg;
using Shop.Presentation.Facade.SliderAgg;
using Shop.Query.ProductAgg.DTOs;

namespace Shop.Api.Controllers
{
    public class ShopController(IBannerFacade bannerFacade, ISliderFacade sliderFacade, IProductFacade productFacade)
        : ApiController
    {
        [HttpGet]
        public async Task<ApiResult<MainPageViewModel>> GetMainPage()
        {
            var banners =await bannerFacade.GetAllBanner();
            var sliders = await sliderFacade.GetAllSlider();
            var latesProductResult = await productFacade.GetForShop(new ProductShopFilterParams()
            {
                PageId = 1,
                Take = 8,
                SearchOrderBy = ProductSearchOrderBy.Latest,
                OnlyAvailableProducts = true
            });
            var specialProductResult = await productFacade.GetForShop(new ProductShopFilterParams
            {
                PageId = 1,
                Take = 8,
                JustHasDiscount = true,
                OnlyAvailableProducts = true
            });
            var bestsellerResult = await productFacade.GetForShop(new ProductShopFilterParams()
            {
                PageId = 1,
                Take = 8,
                OnlyAvailableProducts = true
            });
            var model = new MainPageViewModel()
            {
               Banners = banners,
               Slider = sliders,
               BestSellersProduct = bestsellerResult.Datas,
               LatesProduct = latesProductResult.Datas,
               SpetialProduct = specialProductResult.Datas,
            };
            return QueryResult(model);
        }
    }
}
