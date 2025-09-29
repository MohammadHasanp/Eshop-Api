using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.SellerAgg.DTOs;

namespace Shop.Query.SellerAgg.Inventory.GetByProductId
{
    public class GetInventoryByProductIdQueryHandler : IQueryHandler<GetInventoryByProductIdQuery, List<SellerInventoryDto>>
    {
        private readonly DapperContext _context;
        public GetInventoryByProductIdQueryHandler(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<SellerInventoryDto>> Handle(GetInventoryByProductIdQuery request, CancellationToken cancellationToken)
        {
            using var connection = _context.CreateConnection();
            var sql = $"SELECT * FROM{_context.Inventories} WHERE ProductId = @productId ";
            var result = await connection.QueryAsync<SellerInventoryDto>(sql, new {productId = request.ProductId });
            return result.ToList();
        }
    }
}
