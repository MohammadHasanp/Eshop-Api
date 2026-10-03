using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.UserAgg.DTOs;
using Shop.Query.UserAgg.Mapper;

namespace Shop.Query.UserAgg.GetList
{
    public class GetAllUserHandler : IQueryHandler<GetAllUserQuery, List<UserDto>>
    {
        private readonly ShopContext _context;
        public GetAllUserHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<List<UserDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.Users.OrderByDescending(u=>u.Id).ToListAsync(cancellationToken);
            return await users.MapList().SetUsersRolesTitles(_context);
        }
    }
}
