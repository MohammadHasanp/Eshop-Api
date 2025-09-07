using Common.Query;
using Shop.Query.UserAgg.DTOs;

namespace Shop.Query.UserAgg.GetByEmail
{
    public record GetUserByEmailqQery(string Email) : IQuery<UserDto>;
}
