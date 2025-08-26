using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.OrderAgg.Enums;
using Shop.Domain.OrderAgg.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.Domain.Exceptions.BaseDomainExceotion;

namespace Shop.Domain.OrderAgg
{
    public class Order : AggregateRoot
    {
        //For EfCore
        private Order() { }
        //Set Order
        public Order(long userId)
        {
            UserId = userId;
            Status = OrderStatus.Pennding;
            Items = new List<OrderItem>();
        }
        //Relation With User
        public long UserId { get; private set; }
        //Status Order
        public OrderStatus Status { get; private set; }
        //Discount To Order
        public OrderDiscount? Discount { get; private set; }
        // Last time the order status changed
        public DateTime LastUpdate { get; private set; }
        //OrderShippingMethod Order
        public OrderShippingMethod? ShippingMethod { get; set; }
        //Relation With OrderItem
        public List<OrderItem> Items { get; private set; }
        //Relation with OrderAddress
        public OrderAddress Address { get; private set; }

        //Sum Total Price Order
        public int TotalPrice
        {
            get
            {
                var TotalPrice = Items.Sum(o => o.TotalPrice);
                if (ShippingMethod != null)
                    TotalPrice += ShippingMethod.ShippingCost;
                if (Discount != null)
                    TotalPrice -= Discount.DiscountAmount;

                return TotalPrice;
            }
        }
        //Count Total Order User
        public int ItemCount => Items.Count;

        //AddAsync In OrderItem
        public void AddItem(OrderItem item)
        {
            Guard();
            var oldItem = Items.FirstOrDefault(i => i.InventoryId == item.InventoryId);
            if (oldItem != null)
            {
                oldItem.ChangeCount(item.Count + oldItem.Count);
                return;
            }
            Items.Add(item);
        }
        //Delete In OrderItem
        public void DeleteItem(long itemId)
        {
            Guard();
            var oldItem = Items.FirstOrDefault(o => o.Id == itemId);
            if (oldItem != null)
            {
                Items.Remove(oldItem);
            }
        }
        //Change Count OrderItem
        public void ChangeCountItem(long itemId, int newCount)
        {
            Guard();
            var item = Items.FirstOrDefault(o => o.Id == itemId);

            if (item == null)
                throw new NullOrEmptyDomainDataException("موردی یافت نشد");

            item.ChangeCount(newCount);
        }
        //Increase Count Item
        public void IncreaseCountItem(long itemId, int newCount)
        {
            var item = Items.FirstOrDefault(i => i.Id == itemId);
            if (item == null)
                throw new InvalidDomainDataException("موردی یافت نشد");

            item.IncreaseCount(newCount);
        }
        //Decreas Count Item
        public void DecCountItem(long itemId, int newCount)
        {
            var item = Items.FirstOrDefault(i => i.Id == itemId);
            if (item == null)
                throw new InvalidDomainDataException("موردی یافت نشد");

            item.DecreaseCount(newCount);
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
        public void Guard()
        {
            if (Status != OrderStatus.Pennding)
            {
                throw new InvalidDomainDataException("امکان ثبت سفارش وجود ندارد");
            }
        }
    }
}

