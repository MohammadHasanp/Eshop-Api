using Common.Application;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.SetActive
{
    public class SetActiveUserHandler : IBaseCommandHandler<SetActiveUserCommand>
    {
        private readonly IUserRepository _repository;
        public SetActiveUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(SetActiveUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();

            user.SetActive(request.IsActive);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
