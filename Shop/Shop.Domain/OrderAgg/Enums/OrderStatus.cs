using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg.Enums
{
    //Type Status
    public enum OrderStatus
    {
        None = 0,
        Pennding = 1,
        Finally = 2,
        Shipping = 3,
        Rejected = 4,
    }
}
