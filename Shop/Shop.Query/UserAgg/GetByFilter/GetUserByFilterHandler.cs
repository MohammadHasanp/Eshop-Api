using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.UserAgg.DTOs;
using Shop.Query.UserAgg.Mapper;

namespace Shop.Query.UserAgg.GetByFilter
{
    public class GetUserByFilterHandler : IQueryHandler<GetUserByFilterQuery, UserFilterResult>
    {
        private readonly ShopContext _context;

        public GetUserByFilterHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<UserFilterResult> Handle(GetUserByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var result = _context.Users.OrderByDescending(u => u.Id).AsQueryable();

            if (!string.IsNullOrWhiteSpace(@params.Email))
                result = result.Where(r => r.Email.Contains(@params.Email));

            if (!string.IsNullOrWhiteSpace(@params.PhoneNumber))
                result = result.Where(r => r.PhoneNumber.Contains(@params.PhoneNumber));

            if (@params.Id != null)
                result = result.Where(u => u.Id == @params.Id);

            var skip = (@params.PageId - 1) * @params.Take;

            var model = new UserFilterResult()
            {
                FilterParams = @params,
                Datas = await result.Skip(skip).Take(@params.Take).
                Select(u => u.MapFilterData()).ToListAsync(cancellationToken)
            };
            model.GeneratePaging(result, @params.Take, @params.PageId);
            return model;
        }
    }
}
