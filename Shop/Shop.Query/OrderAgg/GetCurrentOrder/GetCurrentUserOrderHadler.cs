using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.OrderAgg.Enums;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.OrderAgg.DTOs;
using Shop.Query.OrderAgg.Mapper;

namespace Shop.Query.OrderAgg.GetCurrentOrder
{
    public class GetCurrentUserOrderHadler : IQueryHandler<GetCurrentUserOrderQuery, OrderDto>
    {
        private readonly ShopContext _context;
        private readonly DapperContext _dapperContext;
        public GetCurrentUserOrderHadler(ShopContext context, DapperContext dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }
        public async Task<OrderDto> Handle(GetCurrentUserOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.UserId == request.UserId && o.Status == OrderStatus.Pennding, cancellationToken);
            if (order == null)
                return null;
            var orderDto = order.Map();

            orderDto.UserFullName = await _context.Users.Where(o => o.Id == order.UserId).Select(o => o.UserName).FirstAsync();
            orderDto.Items = await orderDto.GetOrderItem(_dapperContext);
            return orderDto;
        }
    }
}
