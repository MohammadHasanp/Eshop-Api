using Common.Query;

namespace Shop.Query.ProductAgg.DTOs
{
    public class ProductImageDto:BaseDto
    {
        public string ImageName { get; set; }
        public long ProductId { get; set; }
        public int Sequence { get; set; }
    }
}
