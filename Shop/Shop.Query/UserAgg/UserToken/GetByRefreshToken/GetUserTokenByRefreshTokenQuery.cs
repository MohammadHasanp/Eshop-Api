using Common.Query;
using Shop.Query.UserAgg.DTOs;

namespace Shop.Query.UserAgg.UserToken.GetByRefreshToken
{
    public record GetUserTokenByRefreshTokenQuery(string HashRefreshToken) : IQuery<UserTokenDto?>;
}
