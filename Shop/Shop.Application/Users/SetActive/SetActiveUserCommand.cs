using Common.Application;

namespace Shop.Application.Users.SetActive
{
    public record SetActiveUserCommand(bool IsActive,long UserId):IBaseCommand;
}
