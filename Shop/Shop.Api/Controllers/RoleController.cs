using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModel.Role;
using Shop.Application.Roles.Create;
using Shop.Application.Roles.Edit;
using Shop.Presentation.Facade.RoleAgg;
using Shop.Query.RoleAgg.DTOs;

namespace Shop.Api.Controllers
{
    //[PermissionChecker(Permission.Role_Management)]
    public class RoleController(IRoleFacade roleFacade) : ApiController
    {
        [HttpGet]
        public async Task<ApiResult<List<RoleDto>>> GetAllRole()
        {
            var result = await roleFacade.GetAllRole();
            return QueryResult(result);
        }
        [HttpGet("{Id}")]
        public async Task<ApiResult<RoleDto>> GetRoleById(long Id)
        {
            var result = await roleFacade.GetRoleById(Id);
            return QueryResult(result);
        }
        [HttpPost]
        public async Task<ApiResult> CreateRole(CreateRoleViewModel viewModel)
        {
            var model = new CreateRoleCommand(viewModel.Title,viewModel.Permissions);
            var result = await roleFacade.Create(model);
            return CommandResult(result);
        }
        [HttpPut]
        public async Task<ApiResult> EditRole(EditRoleViewModel viewModel)
        {
            var model = new EditRoleCommand(viewModel.roleId,viewModel.Title,viewModel.Permissions);
            var result = await roleFacade.Edit(model);
            return CommandResult(result);
        }
        [HttpDelete("{roleId}")]
        public async Task<ApiResult> DeleteRole(long roleId)
        {
            var result = await roleFacade.Delete(roleId);
            return CommandResult(result);
        }
    }
}
