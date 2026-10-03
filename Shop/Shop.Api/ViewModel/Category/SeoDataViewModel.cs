using Common.Domain.ValueObjects;

namespace Shop.Api.ViewModel.Category
{
    public class SeoDataViewModel
    {
        public string MetaTitle { get;  set; }
        public string? MetaDescription { get;  set; }
        public string? MetaKeyWords { get;  set; }
        public bool IndexPage { get; set; }
        public string? Canonical { get;  set; }
        public string? Schema { get;  set; }



        public SeoData MapToSeoData()
        {
            return new SeoData(MetaTitle,MetaDescription,MetaKeyWords,IndexPage,Canonical,Schema);
        }
    }
}
