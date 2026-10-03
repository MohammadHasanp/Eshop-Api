using Common.Domain;

namespace Shop.Domain.OrderAgg.ValueObjects
{
    public class OrderDiscount:ValueObject
    {
        //Title Discount
        public string DiscountTitle { get;private set; }
        //Amount Discount
        public int DiscountAmount { get; private set; }

        //Set OrderDiscount
        public OrderDiscount(string discountTitle, int discountAmount)
        {
            DiscountTitle = discountTitle;
            DiscountAmount = discountAmount;
        }
    }
}
