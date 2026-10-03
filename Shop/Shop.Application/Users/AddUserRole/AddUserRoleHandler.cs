
using Common.Application;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.AddUserRole
{
    public class AddUserRoleHandler : IBaseCommandHandler<AddUserRoleCommand>
    {
        private readonly IUserRepository _repository;
        public AddUserRoleHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();

            user.SetRoles(request.Roles);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
