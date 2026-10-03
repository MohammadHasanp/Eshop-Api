using Shop.Domain.SiteEntities;

namespace Shop.Api.ViewModel.Banners
{
    public class EditBannerViewModel
    {
        public long BannerId { get; set; }
        public string Link { get;  set; }
        public IFormFile? ImageFile { get;  set; }
        public BannerPosition Position { get;  set; }
    }
}
