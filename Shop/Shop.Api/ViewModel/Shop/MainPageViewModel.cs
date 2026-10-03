using Shop.Query.BannerAgg.DTOs;
using Shop.Query.ProductAgg.DTOs;
using Shop.Query.SliderAgg.DTOs;

namespace Shop.Api.ViewModel.Shop
{
    public class MainPageViewModel
    {
        public List<BannerDto> Banners { get; set; }
        public List<SliderDto> Slider { get; set; }
        public List<ProductShopDto> SpetialProduct { get; set; }
        public List<ProductShopDto> LatesProduct { get; set; }
        public List<ProductShopDto> BestSellersProduct { get; set; }
    }
}
