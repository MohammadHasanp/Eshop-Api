using Common.Application;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Repository;

namespace Shop.Application.Roles.Create
{
    public class CreateRuleCommandHandler : IBaseCommandHandler<CreateRoleCommand>
    {
        private readonly IRoleRepository _repository;

        public CreateRuleCommandHandler(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var permisstions = new List<RolePermission>();
            request.Permissions.ForEach(permisstion =>
            {
                permisstions.Add(new RolePermission(permisstion));
            });
            var role = new Role(request.Title, permisstions);
            await _repository.AddAsync(role);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
