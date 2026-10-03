using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.CategoryAgg.DTOs;
using Shop.Query.CategoryAgg.Mapper;

namespace Shop.Query.CategoryAgg.GetById
{
    public class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly ShopContext _context;
        public GetCategoryByIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var model= await _context.Categories.FirstOrDefaultAsync(c=>c.Id == request.categoryId,cancellationToken);
            //if (model == null)
            //    throw new Exception();
            return model.Map();
        }
    }
}
