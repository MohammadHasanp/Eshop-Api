using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.CategoryAgg.DTOs;
using Shop.Query.CategoryAgg.Mapper;

namespace Shop.Query.CategoryAgg.GetByParentId
{
    public class GetCategoryParentIdHandler : IQueryHandler<GetCategoryByParentIdQuery, List<SubCategoryDto>>
    {
        private readonly ShopContext _context;
        public GetCategoryParentIdHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<List<SubCategoryDto>> Handle(GetCategoryByParentIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _context.Categories.Include(c => c.Childs).Where(c => c.ParentId == request.ParentId).ToListAsync(cancellationToken);
            return model.MapChildren();
        }
    }
}
