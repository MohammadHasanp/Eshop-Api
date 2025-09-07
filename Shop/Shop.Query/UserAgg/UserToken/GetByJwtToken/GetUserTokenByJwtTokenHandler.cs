using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.UserAgg.DTOs;

namespace Shop.Query.UserAgg.UserToken.GetByJwtToken
{
    public class GetUserTokenByJwtTokenHandler : IQueryHandler<GetUserTokenByJwtTokenQuery, UserTokenDto>
    {
        private readonly DapperContext _dapperContext;
        public GetUserTokenByJwtTokenHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<UserTokenDto> Handle(GetUserTokenByJwtTokenQuery request, CancellationToken cancellationToken)
        {
            using var connection = _dapperContext.CreateConnection();
            var sql = $"SELECT TOP(1) * FROM {_dapperContext.UserTokens} WHERE HashJwtToken = @HashJwtToken";
            return await connection.QueryFirstOrDefaultAsync<UserTokenDto>(sql, new { HashJwtToken = request.HashJwtToken});

        }
    }
}
