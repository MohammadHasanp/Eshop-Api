namespace Shop.Api.ViewModel.Category
{
    public class AddChildCategoryViewModel
    {
        public long ParentId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public SeoDataViewModel SeoData { get; set; }
    }
}
