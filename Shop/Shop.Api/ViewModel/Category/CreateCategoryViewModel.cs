using Common.Domain.ValueObjects;

namespace Shop.Api.ViewModel.Category
{
    public class CreateCategoryViewModel
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public SeoDataViewModel  SeoData{ get; set; }
    }
    public class EditCategoryViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public SeoDataViewModel SeoData { get; set; }
    }
}
