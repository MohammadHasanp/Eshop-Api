using Microsoft.Data.SqlClient;
using System.Data;

namespace Shop.Infrastructure.Persistent.Dapper
{
    public class DapperContext
    {
        private readonly string _connection;

        public DapperContext(string connection)
        {
            _connection = connection;
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connection);

        public string Inventories = "[seller].Inventories";
        public string OrderItems = "[order].Items";
        public string UserAddress = "[user].UserAddress";
        public string Sellers = "[seller].Sellers";
        public string Products = "[product].Products";
        public string UserTokens = "[user].Tokens";
    }
}
