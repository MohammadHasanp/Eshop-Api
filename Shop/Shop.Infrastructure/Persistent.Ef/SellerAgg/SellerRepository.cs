using Common.Domain.Repository;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Infrastructure._Utilities;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef._Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.SellerAgg
{
    public class SellerRepository : BaseRepository<Seller>, ISellerRepository
    {
        private readonly DapperContext _dapper;
        public SellerRepository(ShopContext context, DapperContext dapper) : base(context)
        {
            _dapper = dapper;
        }
        public async Task<InventoryResult?> GetInventoryById(long id)
        {
            //return await _context.SellerInventories.Where(p => p.Id == id)
            //    .Select(i => new InventoryResult
            //    {
            //        Count = i.Count,
            //        Id = i.Id,
            //        Price = i.Price,
            //        ProductID = i.ProductId,
            //        SellerId = i.SellerId
            //    }).FirstOrDefaultAsync();

            using var connection = _dapper.CreateConnection();
            var sql = $"SELECT * FROM {_dapper.Inventories} where id = id";
            return await connection.QueryFirstOrDefaultAsync<InventoryResult>(sql,new {id = id});
        }
    }
}
