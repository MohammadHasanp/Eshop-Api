using Common.Query;
using Shop.Query.SellerAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.SellerAgg.GetById
{
    public record GetSellerByIdQuery(long SellerId):IQuery<SellerDto>;
}
