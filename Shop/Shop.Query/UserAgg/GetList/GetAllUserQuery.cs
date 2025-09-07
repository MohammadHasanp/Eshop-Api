using Common.Query;
using Shop.Query.UserAgg.DTOs;

namespace Shop.Query.UserAgg.GetList
{
    public record GetAllUserQuery():IQuery<List<UserDto>>;
}
