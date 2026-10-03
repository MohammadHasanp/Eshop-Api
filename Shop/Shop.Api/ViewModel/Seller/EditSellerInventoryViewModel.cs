namespace Shop.Api.ViewModel.Seller
{
    public class EditSellerInventoryViewModel
    {
        public long InventoryId { get; set; }
        public long SellerId { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public int DiscountPercentage { get; set; }
    }
}
