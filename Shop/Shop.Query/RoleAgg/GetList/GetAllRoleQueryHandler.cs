using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.RoleAgg.DTOs;
using Shop.Query.RoleAgg.Mapper;

namespace Shop.Query.RoleAgg.GetList
{
    public class GetAllRoleQueryHandler : IQueryHandler<GetAllRoleQuery, List<RoleDto>>
    {
        private readonly ShopContext _context;
        public GetAllRoleQueryHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<List<RoleDto>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            var model = await _context.Roles.OrderByDescending(c => c.Id).ToListAsync(cancellationToken);
            return model.MapList();
        }
    }
}
