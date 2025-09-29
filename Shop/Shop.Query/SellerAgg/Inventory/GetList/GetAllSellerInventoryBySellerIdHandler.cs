using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.SellerAgg.DTOs;

namespace Shop.Query.SellerAgg.Inventory.GetList
{
    public class GetAllSellerInventoryBySellerIdHandler : IQueryHandler<GetAllSellerInventoryBySellerIdQuery, List<SellerInventoryDto>>
    {
        private readonly DapperContext _context;
        public GetAllSellerInventoryBySellerIdHandler(DapperContext context)
        {
            _context = context;
        }
        public async Task<List<SellerInventoryDto>> Handle(GetAllSellerInventoryBySellerIdQuery request, CancellationToken cancellationToken)
        {
            using var connection = _context.CreateConnection();
            var sql = @$"SELECT i.Id, SellerId , ProductId ,Count , Price,i.CreationDate , DiscountPercentage , s.ShopName,
                         p.Title as ProductTitle,p.ImageName as ProductImage from {_context.Inventories}
                         i inner join {_context.Sellers} s on i.SellerId = s.Id
                         inner join {_context.Products} p on i.ProductId = p.Id where i.SellerId = @sellerId";

            var inventories = await connection.QueryAsync<SellerInventoryDto>(sql, new { sellerId = request.SellerId});
            return inventories.ToList();

        }
    }
}
