using Shop.Domain.SellerAgg;
using Shop.Query.SellerAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.SellerAgg.Mapper
{
    public static class SellerMapper
    {
        public static SellerDto Map(this Seller seller)
        {
            return new SellerDto()
            {
                CreationDate = seller.CreationDate,
                Id = seller.Id,
                NationalCode = seller.NationalCode,
                ShopName = seller.ShopName,
                Status = seller.Status,
                UserId = seller.UserId
            };
        }
    }
}
