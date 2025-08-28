using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.RoleAgg.DTOs;
using Shop.Query.RoleAgg.Mapper;

namespace Shop.Query.RoleAgg.GetById
{
    public class GetRoleByIdHandler : IQueryHandler<GetRoleByIdQuery, RoleDto>
    {
        private readonly ShopContext _context;
        public GetRoleByIdHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<RoleDto> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r=>r.Id == request.RoleId);

            if (role == null)
                return null;

            return role.Map();
        }
    }
}
