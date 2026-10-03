
using Common.Application;
using Shop.Domain.UserAgg;

namespace Shop.Application.Users.AddUserRole
{
    public record AddUserRoleCommand(long UserId,List<UserRole> Roles):IBaseCommand;
}
