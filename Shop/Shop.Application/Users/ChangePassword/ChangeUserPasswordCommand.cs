
using Common.Application;
using Common.Application.Validation.FluentValidations;

namespace Shop.Application.Users.ChangePassword
{
    public class ChangeUserPasswordCommand:IBaseCommand
    {
        public long UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }

        public ChangeUserPasswordCommand(string currentPassword, string newPassword)
        {
            CurrentPassword = currentPassword;
            NewPassword = newPassword;
        }
    }
}
