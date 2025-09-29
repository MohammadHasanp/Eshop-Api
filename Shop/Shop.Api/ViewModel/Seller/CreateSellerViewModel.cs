using Shop.Domain.SellerAgg.Enums;

namespace Shop.Api.ViewModel.Seller
{
    public class CreateSellerViewModel
    {
        public string ShopName { get; set; }
        public string NationalCode { get; set; }
    }
    public class EditSellerViewModel
    {
        public long Id { get; set; }
        public string ShopName { get; set; }
        public SellerStatus Status{ get; set; }
        public string NationalCode { get; set; }
    }
}
