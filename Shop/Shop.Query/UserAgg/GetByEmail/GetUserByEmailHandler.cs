using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.UserAgg.DTOs;
using Shop.Query.UserAgg.Mapper;

namespace Shop.Query.UserAgg.GetByPhoneNumber
{
    public class GetUserByEmailHandler : IQueryHandler<GetUserByEmailqQery, UserDto>
    {
        private readonly ShopContext _context;
        public GetUserByEmailHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<UserDto> Handle(GetUserByEmailqQery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
                return null;
            return await user.Map().SetUserRoleTitles(_context);
        }
    }
}
