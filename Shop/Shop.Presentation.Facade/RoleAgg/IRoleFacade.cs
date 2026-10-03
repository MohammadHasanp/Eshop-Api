

using Common.Application;
using Shop.Application.Roles.Create;
using Shop.Application.Roles.Delete;
using Shop.Application.Roles.Edit;
using Shop.Application.Users.Register;
using Shop.Query.RoleAgg.DTOs;

namespace Shop.Presentation.Facade.RoleAgg
{
    public interface IRoleFacade
    {
        Task<OperationResult> Create(CreateRoleCommand command);
        Task<OperationResult> Edit(EditRoleCommand command);
        Task<OperationResult> Delete(long RoleId);
        Task<RoleDto>GetRoleById(long roleId);
        Task<List<RoleDto>> GetAllRole();
    }
}
