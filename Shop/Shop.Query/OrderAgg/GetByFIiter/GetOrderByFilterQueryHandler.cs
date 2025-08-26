using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.OrderAgg.DTOs;
using Shop.Query.OrderAgg.Mapper;

namespace Shop.Query.OrderAgg.GetByFIiter
{
    public class GetOrderByFilterQueryHandler : IQueryHandler<GetOrderByFilterQuery, OrderFilterResult>
    {
        private readonly ShopContext _context;
        public GetOrderByFilterQueryHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<OrderFilterResult> Handle(GetOrderByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var result = _context.Orders.OrderByDescending(o => o.Id).AsQueryable();
            if (@params.UserId != null)
            {
                result = result.Where(o=>o.UserId == @params.UserId);
            }
            if (@params.StartDate != null)
            {
                result = result.Where(o => o.CreationDate.Date >= @params.StartDate.Value.Date);
            }
            if (@params.EndDate != null)
            {
                result = result.Where(o => o.CreationDate.Date <= @params.EndDate.Value.Date);
            }
            if (@params.Status != null)
            {
                result = result.Where(o => o.Status == @params.Status);
            }
            var skip = (@params.PageId-1)* @params.Take;
            var model = new OrderFilterResult()
            {
                Datas = await result.Skip(skip).Take(@params.Take).Select(order => order.MapFilterDate(_context)).ToListAsync(cancellationToken),
                FilterParams = @params
            };
            return model;
        }
    }
}
