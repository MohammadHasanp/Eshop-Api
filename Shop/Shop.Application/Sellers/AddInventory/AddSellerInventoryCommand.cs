using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Sellers.AddInventory
{
    public class AddSellerInventoryCommand:IBaseCommand
    {
        public long SellerId { get; private set; }
        public long ProductId { get; private set; }
        public int Price { get; private set; }
        public int Count { get; private set; }
        public int? DiscountPercentage { get; private set; }


        public AddSellerInventoryCommand(long sellerId,long productId, int price, int count, int? discountPercentage)
        {
            SellerId = sellerId;
            ProductId = productId;
            Price = price;
            Count = count;
            DiscountPercentage = DiscountPercentage;
        }
    }
}
