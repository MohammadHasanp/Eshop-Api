using Common.Domain.ValueObjects;
using Common.Query;

namespace Shop.Query.CategoryAgg.DTOs
{
    public class SubCategoryDto:BaseDto
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public SeoData SeoData { get; set; }
        public long PrantId { get; set; }
        public List<SecondaryChildCategoryDto> Childs { get; set; }
    }
}
