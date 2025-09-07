using Common.Query;
using Shop.Query.UserAgg.DTOs;

namespace Shop.Query.UserAgg.GetByFilter
{
    public class GetUserByFilterQuery : QueryFilter<UserFilterResult, UserFilterParams>
    {
        public GetUserByFilterQuery(UserFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
