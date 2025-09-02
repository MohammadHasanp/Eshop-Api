using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.CategoryAgg.DTOs;
using Shop.Query.CategoryAgg.Mapper;

namespace Shop.Query.CategoryAgg.GetList
{
    public class GetCategoryListQueryHandler : IQueryHandler<GetCategoryListQuery, List<CategoryDto>>
    {
        private readonly ShopContext _context;
        public GetCategoryListQueryHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var model = await _context.Categories
                .Where(c=>c.ParentId == null)
                .Include(c=>c.Childs)
                .ThenInclude(c=>c.Childs).OrderByDescending(c=>c.Id).ToListAsync(cancellationToken);
            return model.Map();
        }
    }
}
