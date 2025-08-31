

using Common.Application;
using MediatR;
using Shop.Application.Roles.Create;
using Shop.Application.Roles.Edit;
using Shop.Query.RoleAgg.DTOs;
using Shop.Query.RoleAgg.GetById;
using Shop.Query.RoleAgg.GetList;

namespace Shop.Presentation.Facade.RoleAgg
{
    public class roleFacade : IRoleFacade
    {
        private readonly IMediator _mediator;
        public roleFacade(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<OperationResult> Create(CreateRoleCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Edit(EditRoleCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<List<RoleDto>> GetAllRole()
        {
            return await _mediator.Send(new GetAllRoleQuery());
        }

        public async Task<RoleDto> GetRoleById(long roleId)
        {
            return await _mediator.Send(new GetRoleByIdQuery(roleId));
        }
    }
}
