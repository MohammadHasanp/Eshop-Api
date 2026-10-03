using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModel.Shop;
using Shop.Presentation.Facade.BannerAgg;
using Shop.Presentation.Facade.ProductAgg;
using Shop.Presentation.Facade.SliderAgg;
using Shop.Query.ProductAgg.DTOs;

namespace Shop.Api.Controllers
{
    public class ShopController : ApiController
    {
        private readonly IBannerFacade _bannerFacade;
        private readonly ISliderFacade _sliderFacade;
        private readonly  IProductFacade _productFacade;
        public ShopController(IBannerFacade bannerFacade, ISliderFacade sliderFacade, IProductFacade productFacade)
        {
            _bannerFacade = bannerFacade;
            _sliderFacade = sliderFacade;
            _productFacade = productFacade;
        }
        [HttpGet]
        public async Task<ApiResult<MainPageViewModel>> GetMainPage()
        {
            var banners =await _bannerFacade.GetAllBanner();
            var sliders = await _sliderFacade.GetAllSlider();
            var latesProductResult = await _productFacade.GetForShop(new ProductShopFilterParams()
            {
                PageId = 1,
                Take = 8,
                SearchOrderBy = ProductSearchOrderBy.Latest,
                OnlyAvailableProducts = true
            });
            var specialProductResult = await _productFacade.GetForShop(new ProductShopFilterParams
            {
                PageId = 1,
                Take = 8,
                JustHasDiscount = true,
                OnlyAvailableProducts = true
            });
            var bestsellerResult = await _productFacade.GetForShop(new ProductShopFilterParams()
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
