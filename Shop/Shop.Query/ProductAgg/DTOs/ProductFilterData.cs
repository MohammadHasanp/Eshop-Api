using Common.Query;

namespace Shop.Query.ProductAgg.DTOs
{
    public class ProductFilterData : BaseDto
    {
        public string Slug { get; set; }
        public string Tilte { get; set; }
        public string ImageName { get; set; }
    }
}
