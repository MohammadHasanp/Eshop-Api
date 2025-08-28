using Common.Query;
using Shop.Query.UserAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.UserAgg.GetByFilter
{
    public class GetUserByFilterQuery : QueryFilter<UserFilterResult, UserFilterParams>
    {
        public GetUserByFilterQuery(UserFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
