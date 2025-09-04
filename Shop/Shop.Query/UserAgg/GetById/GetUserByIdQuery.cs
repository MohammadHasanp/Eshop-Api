using Common.Query;
using Shop.Query.UserAgg.DTOs;

namespace Shop.Query.UserAgg.GetById
{
    public record GetUserByIdQuery(long UserId):IQuery<UserDto>;
}
