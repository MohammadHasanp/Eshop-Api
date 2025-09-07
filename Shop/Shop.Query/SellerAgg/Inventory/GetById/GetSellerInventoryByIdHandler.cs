using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.SellerAgg.DTOs;

namespace Shop.Query.SellerAgg.Inventory.GetById
{
    public class GetSellerInventoryByIdHandler : IQueryHandler<GetSellerInventoryByIdQuery, SellerInventoryDto?>
    {
        private readonly DapperContext _context;
        public GetSellerInventoryByIdHandler(DapperContext context)
        {
            _context = context;
        }
        public Task<SellerInventoryDto?> Handle(GetSellerInventoryByIdQuery request, CancellationToken cancellationToken)
        {
            using var connection = _context.CreateConnection();
            var sql = @$"SELECT Top(1) i.Id, SellerId , ProductId ,Count , Price,i.CreationDate , DiscountPercentage , s.ShopName,
                         p.Title as ProductTitle,p.ImageName as ProductImage from {_context.Inventories}
                         i inner join {_context.Sellers} s on i.SellerId = s.Id
                         inner join {_context.Products} p on i.ProductId = p.Id where i.Id = @Id";

            var inventory = connection.QueryFirstOrDefaultAsync<SellerInventoryDto>(sql, new {Id = request.Id });

            if (inventory == null)
                return null;

            return inventory;
        }
    }
}
