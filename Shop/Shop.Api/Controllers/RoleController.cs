using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Roles.Create;
using Shop.Application.Roles.Edit;
using Shop.Presentation.Facade.RoleAgg;
using Shop.Query.RoleAgg.DTOs;

namespace Shop.Api.Controllers
{
    public class RoleController : ApiController
    {
        private readonly IRoleFacade _roleFacade;
        public RoleController(IRoleFacade roleFacade)
        {
            _roleFacade = roleFacade;
        }
        [HttpGet]
        public async Task<ApiResult<List<RoleDto>>> GetAllRole()
        {
            var result = await _roleFacade.GetAllRole();
            return QueryResult(result);
        }
        [HttpGet("{Id}")]
        public async Task<ApiResult<RoleDto>> GetRoleById(long Id)
        {
            var result = await _roleFacade.GetRoleById(Id);
            return QueryResult(result);
        }
        [HttpPost]
        public async Task<ApiResult> CreateRole(CreateRoleCommand command)
        {
            var result = await _roleFacade.Create(command);
            return CommandResult(result);
        }
        [HttpPut]
        public async Task<ApiResult> EditRole(EditRoleCommand command)
        {
            var result = await _roleFacade.Edit(command);
            return CommandResult(result);
        }
    }
}
