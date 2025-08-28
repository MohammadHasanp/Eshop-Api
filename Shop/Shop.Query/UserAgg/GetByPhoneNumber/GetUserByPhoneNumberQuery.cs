using Common.Query;
using Shop.Query.UserAgg.DTOs;

namespace Shop.Query.UserAgg.GetByPhoneNumber
{
    public record GetUserByPhoneNumberQuery(string PhoneNumber):IQuery<UserDto>;
}
