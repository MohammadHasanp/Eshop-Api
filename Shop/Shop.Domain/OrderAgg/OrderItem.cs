using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using static Common.Domain.Exceptions.BaseDomainExceotion;

namespace Shop.Domain.OrderAgg
{
    public class OrderItem:BaseEntity
    {
        //Set OrderItem
        public OrderItem(long inventoryId, int count, int price)
        {
            Guard(price,count);
            InventoryId = inventoryId;
            Count = count;
            Price = price;
        }
        //Relation With Order
        public long OrderId { get; internal set; }
        //
        public long InventoryId { get;private set; }
        //Count Order
        public int Count { get;private set; }
        //Price Order
        public int Price { get;private set; }
        //Total Price Order
        public int TotalPrice => Price * Count;

        //Change Count OrderItem
        public void ChangeCount(int newCount)
        {
               Guard(0,newCount);
               Count = newCount;
        }
        //Set Price OrderItem
        public void SetPrice(int newPrice)
        {
            Guard(newPrice,0);
            Price = newPrice;
        }
        //Validation OrderItem 
        public void Guard(int price,int count)
        {
            if (price != 0)
                if (Price < 1)
                    throw new InvalidDomainDataException("Price InValid");

            if (count != 0)
                if (count < 1)
                    throw new InvalidDomainDataException("Count InValid");
        }
    }
}
