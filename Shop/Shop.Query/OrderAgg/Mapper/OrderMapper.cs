using Dapper;
using Shop.Domain.OrderAgg;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.OrderAgg.DTOs;


namespace Shop.Query.OrderAgg.Mapper
{
    public static class OrderMapper
    {
        public static OrderFilterData MapFilterDate(this Order order, ShopContext context)
        {
            var userFullName = context.Users.Where(u => u.Id == order.UserId).Select(u => u.UserName).First();

            return new OrderFilterData()
            {
                City = order.Address?.City,
                CreationDate = order.CreationDate,
                Id = order.Id,
                ShippingType = order.ShippingMethod?.ShippingType,
                Shire = order.Address?.Shire,
                Status = order.Status,
                TotalItemCount = order.ItemCount,
                TotalPrice = order.TotalPrice,
                UserFullName = userFullName,
                UserId = order.UserId,
                LastUpdate = order.LastUpdate,
            };
        }
        public static async Task<List<OrderItemDto>> GetOrderItem(this OrderDto orderDto, DapperContext dapperContext)
        {
            var connection = dapperContext.CreateConnection();
            var sql = @$"SELECT o.Id, s.ShopName ,o.OrderId,o.InventoryId,o.Count,o.price,
                          p.Title as ProductTitle , p.Slug as ProductSlug ,
                          p.ImageName as ProductImageName FROM{dapperContext.OrderItems} o 
                      Inner Join {dapperContext.Inventories} i on o.InventoryId = i.Id
                      Inner Join {dapperContext.Products} p on i.ProductId = p.Id
                      Inner Join {dapperContext.Sellers} s on i.SellerId = s.Id
                      where o.OrderId = @orderId ";
            var result = await connection.QueryAsync<OrderItemDto>(sql, new { OrderId = orderDto.Id });
            return result.ToList();
        }
        public static OrderDto Map(this Order order)
        {
            return new OrderDto()
            {
                Id = order.Id,
                Address = order.Address,
                CreationDate = order.CreationDate,
                Discount = order.Discount,
                Items = new(),
                LastUpdate = order.LastUpdate,
                ShippingMethod = order.ShippingMethod,
                Status = order.Status,
                UserId = order.UserId,
                UserFullName = ""
            };
        }
    }
}
