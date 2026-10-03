using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.UserAgg.DTOs;
using Shop.Query.UserAgg.Mapper;

namespace Shop.Query.UserAgg.GetByPhoneNumber
{
    public class GetUserByPhoneNumberHandler : IQueryHandler<GetUserByPhoneNumberQuery, UserDto>
    {
        private readonly ShopContext  _context;
        public GetUserByPhoneNumberHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<UserDto> Handle(GetUserByPhoneNumberQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u=>u.PhoneNumber == request.PhoneNumber);

            if (user == null)
                return null;

            return await user.Map().SetUserRoleTitles(_context);
        }
    }
}
