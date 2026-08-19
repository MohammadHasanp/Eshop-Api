
using Common.Application;
using Common.Application.SecurityUtil;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.ChangePassword
{
    internal class ChangeUserPasswordHandler : IBaseCommandHandler<ChangeUserPasswordCommand>
    {
        private readonly IUserRepository _repository;
        public ChangeUserPasswordHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.UserId);

            if(user == null)
                return OperationResult.NotFound("کاربر مورد نظر یافت نشد");

            var currentPasswordHash = Sha256Hasher.Hash(request.CurrentPassword);
            var newPasswordHash = Sha256Hasher.Hash(request.NewPassword);

            if (currentPasswordHash != user.Password)
               return OperationResult.Error("اطلاعات وارد شده معتبر نمیباشد");

            user.ChangePassword(newPasswordHash); 
            await _repository.Save();
            return OperationResult.Success(); 
        }
    }
}
