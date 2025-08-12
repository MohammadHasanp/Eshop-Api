using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg.ValueObjects
{
    public class ShippingMethode:ValueObject
    {
        public string ShippingType{ get;private set; }
        public int ShippingCost{ get; private set; }

        public ShippingMethode(string shippingType, int shippingCost)
        {
            ShippingType = shippingType;
            ShippingCost = shippingCost;
        }
    }
}
