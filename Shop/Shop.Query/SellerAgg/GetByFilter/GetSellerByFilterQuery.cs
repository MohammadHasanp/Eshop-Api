using Common.Query;
using Shop.Query.SellerAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.SellerAgg.GetByFilter
{
    public class GetSellerByFilterQuery : QueryFilter<SellerFilterResult, SellerFilterParams>
    {
        public GetSellerByFilterQuery(SellerFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
