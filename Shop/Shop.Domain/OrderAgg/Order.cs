using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.OrderAgg.Enums;
using Shop.Domain.OrderAgg.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg
{
    public class Order : AggregateRoot
    {
        private Order() { }

        public Order(long userId)
        {
            UserId = userId;
            Status = OrderStatus.Pennding;
            OrderItems = new List<OrderItem>();
        }
        public long UserId { get; private set; }
        public OrderStatus Status { get; private set; }
        public OrderDiscount? Discount { get; private set; }
        public OrderAddress Address { get; private set; }
        public DateTime LastUpdate { get; private set; }
        public ShippingMethode? ShippingMethode { get; set; }
        public List<OrderItem> OrderItems { get; private set; }

        public int TotalPrice
        {
            get
            {
                var TotalPrice = OrderItems.Sum(o => o.TotalPrice);
                if (ShippingMethode != null)
                    TotalPrice += ShippingMethode.ShippingCost;
                if (Discount != null)
                    TotalPrice -= Discount.DiscountAmount;

                return TotalPrice;
            }
        }
        public int ItemCount => OrderItems.Count;

        public void AddItem(OrderItem orderItem)
        {
            OrderItems.Add(orderItem);
        }
        public void DeleteItem(long itemId)
        {
            var oldItem = OrderItems.FirstOrDefault(o => o.Id == itemId);
            if (oldItem != null)
            {
                OrderItems.Remove(oldItem);
            }
        }
        public void ChangeCountItem(long itemId, int newCount)
        {
            var item = OrderItems.FirstOrDefault(o => o.Id == itemId);

            if (item == null)
                throw new NullOrEmptyDomainDataException("Not Found Item");

            item.ChangeCount(newCount);
        }
        public void ChangeStatus(OrderStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }
        //Fainally Order
        public void Checkout(OrderAddress address)
        {
            Address = address;
        }
    }
}

