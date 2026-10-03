using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.UserAgg.DTOs;

namespace Shop.Query.UserAgg.Adrersses.GetList
{
    public record GetAllUserAddressQuery(long UserId):IQuery<List<AddressDto>>;



    public class GetAllUserAddressHandler : IQueryHandler<GetAllUserAddressQuery, List<AddressDto>>
    {
        private readonly DapperContext _context;
        public GetAllUserAddressHandler(DapperContext context)
        {
            _context = context;
        }
        public async Task<List<AddressDto>> Handle(GetAllUserAddressQuery request, CancellationToken cancellationToken)
        {
            var sql = $"select * from{_context.UserAddress} WHERE UserId = @UserId ";
            var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<AddressDto>(sql,new {UserId = request.UserId});
            return result.ToList();
        }
    }
}
