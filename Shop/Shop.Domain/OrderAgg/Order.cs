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
        //Status Order
        public OrderStatus Status { get; private set; }
        //Discount To Order
        public OrderDiscount? Discount { get; private set; }
        // Last time the order status changed
        public DateTime LastUpdate { get; private set; }
        //ShippingMethode Order
        public ShippingMethode? ShippingMethode { get; set; }
        //Relation With OrderItem
        public List<OrderItem> OrderItems { get; private set; }
        //Relation with OrderAddress
        public OrderAddress Address { get; private set; }

        //Sum Total Order Related User
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
        //Count Total Order User
        public int ItemCount => OrderItems.Count;

        //Add In OrderItem
        public void AddItem(OrderItem orderItem)
        {
            OrderItems.Add(orderItem);
        }
        //Delete In OrderItem
        public void DeleteItem(long itemId)
        {
            var oldItem = OrderItems.FirstOrDefault(o => o.Id == itemId);
            if (oldItem != null)
            {
                OrderItems.Remove(oldItem);
            }
        }
        //Change Count OrderItem
        public void ChangeCountItem(long itemId, int newCount)
        {
            var item = OrderItems.FirstOrDefault(o => o.Id == itemId);

            if (item == null)
                 throw new NullOrEmptyDomainDataException("Not Found Item");

            item.ChangeCount(newCount);
        }
        //Change Status OrderItem
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

