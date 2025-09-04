using Common.Query;
using Shop.Query.UserAgg.DTOs;

namespace Shop.Query.UserAgg.UserToken.GetByJwtToken
{
    public record GetUserTokenByJwtTokenQuery(string HashJwtToken):IQuery<UserTokenDto>;
}
