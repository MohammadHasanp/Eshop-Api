using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.SellerAgg.DTOs;
using Shop.Query.SellerAgg.Mapper;

namespace Shop.Query.SellerAgg.GetByFilter
{
    public class GetSellerByFilterHandler : IQueryHandler<GetSellerByFilterQuery, SellerFilterResult>
    {
        private readonly ShopContext _context;
        public GetSellerByFilterHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<SellerFilterResult> Handle(GetSellerByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var result = _context.Sellers.OrderByDescending(p => p.Id).AsQueryable();

            if (!string.IsNullOrWhiteSpace(@params.ShopName))
                result = result.Where(s => s.ShopName == @params.ShopName);

            if (!string.IsNullOrWhiteSpace(@params.NationalCode))
                result = result.Where(s => s.NationalCode == @params.NationalCode);

            var skip = (@params.PageId - 1) * @params.Take;

            var model = new SellerFilterResult()
            {
                FilterParams = @params,
                Datas = await result.Skip(skip).Take(@params.Take).Select(s => s.Map()).ToListAsync(cancellationToken)
            };
            model.GeneratePaging(result, @params.Take, @params.PageId);
            return model;
        }
    }
}
