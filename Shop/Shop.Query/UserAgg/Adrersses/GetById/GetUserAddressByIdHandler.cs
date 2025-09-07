using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.UserAgg.DTOs;

namespace Shop.Query.UserAgg.Adrersses.GetById
{
    public class GetUserAddressByIdHandler : IQueryHandler<GetUserAddressByIdQuery, AddressDto>
    {
        private readonly DapperContext _dapperContext;

        public GetUserAddressByIdHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<AddressDto?> Handle(GetUserAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var sql = $"SELECT TOP 1 FROM {_dapperContext.UserAddress} WHERE Id == @AdressId";
            using var context = _dapperContext.CreateConnection();
            return await context.QueryFirstOrDefaultAsync<AddressDto>(sql, new {AddresId =request.AddressId});
        }
    }
}
