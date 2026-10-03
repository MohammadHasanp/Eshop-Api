using Common.Query;
using Shop.Query.SellerAgg.DTOs;


namespace Shop.Query.SellerAgg.GetByFilter
{
    public class GetSellerByFilterQuery : QueryFilter<SellerFilterResult, SellerFilterParams>
    {
        public GetSellerByFilterQuery(SellerFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
