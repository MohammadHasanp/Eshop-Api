
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.OrderAgg.DTOs;
using Shop.Query.OrderAgg.Mapper;

namespace Shop.Query.OrderAgg.GetById
{
    public class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderDto?>
    {
        private readonly ShopContext _context;
        private readonly DapperContext _dapperContext;
        public GetOrderByIdQueryHandler(ShopContext context, DapperContext dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }
        public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == request.OrderId, cancellationToken);
            if (order == null)
                return null;
            var orderDto = order.Map();
            orderDto.UserFullName = await _context.Users.Where(u => u.Id == order.UserId).Select(u => u.UserName).FirstAsync();

            orderDto.Items = await orderDto.GetOrderItem(_dapperContext);
            return orderDto;  
        }
    }
}
