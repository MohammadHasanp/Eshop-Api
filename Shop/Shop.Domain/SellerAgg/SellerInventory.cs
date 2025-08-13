using Common.Domain;
using static Common.Domain.Exceptions.BaseDomainExceotion;

namespace Shop.Domain.SellerAgg
{
    public class SellerInventory:BaseEntity
    {
        //Relation with Seller
        public long SellerId { get;internal set; }
        //Relation With Product
        public long ProductId { get;private set; }
        //Price Inventory
        public int Price { get;private set; }
        //Count Inventory
        public int Count { get;private set; }
        //Set SellerInventory
        public SellerInventory(long productId, int price, int count)
        {
            Guard(price,count);
            ProductId = productId;
            Price = price;
            Count = count;
        }
        //Validation SellerInventory
        public void Guard(int price,int count)
        {
            if (price < 1)
                throw new InvalidDomainDataException("Price InValid");
            if (count < 0)
                throw new InvalidDomainDataException("Count InValid");
        }
    }
}
