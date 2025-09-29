
using Common.Application;
using Shop.Domain.RoleAgg.Repository;

namespace Shop.Application.Roles.Delete
{
    public record DeleteRoleCommand(long RoleId):IBaseCommand;

    public class DeleteRoleHandler : IBaseCommandHandler<DeleteRoleCommand>
    {
        private readonly IRoleRepository _repository;
        public DeleteRoleHandler(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _repository.GetTracking(request.RoleId);
            if (role == null)
                return OperationResult.NotFound();

            _repository.Delete(role);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
