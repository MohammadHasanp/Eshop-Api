using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string Sellers = "[seller].Sellers";
        public string Products = "[product].Products";
    }
}
