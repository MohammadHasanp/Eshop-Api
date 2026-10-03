using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.UserAgg.DTOs;
using Shop.Query.UserAgg.Mapper;

namespace Shop.Query.UserAgg.GetById
{
    public class GetUserByIdHandler : IQueryHandler<GetUserByIdQuery, UserDto>
    {
        private readonly ShopContext _context;

        public GetUserByIdHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u=>u.Id == request.UserId,cancellationToken);

            if (user == null)
                return null;

            return await user.Map().SetUserRoleTitles(_context);
        }
    }
}
