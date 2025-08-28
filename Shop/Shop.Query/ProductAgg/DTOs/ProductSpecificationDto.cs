using Common.Query;

namespace Shop.Query.ProductAgg.DTOs
{
    public class ProductSpecificationDto:BaseDto
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
