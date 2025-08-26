using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg.ValueObjects
{
    public class OrderShippingMethod:ValueObject
    {
        //Shipping Type
        public string ShippingType{ get;private set; }
        //Shipping Amount
        public int ShippingCost{ get; private set; }
        //Set Shipping Methode
        public OrderShippingMethod(string shippingType, int shippingCost)
        {
            ShippingType = shippingType;
            ShippingCost = shippingCost;
        }
    }
}
