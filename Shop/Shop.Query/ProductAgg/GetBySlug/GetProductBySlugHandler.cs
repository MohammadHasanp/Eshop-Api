using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.ProductAgg.DTOs;
using Shop.Query.ProductAgg.Mapper;

namespace Shop.Query.ProductAgg.GetBySlug
{
    public class GetProductBySlugHandler : IQueryHandler<GetProductBySlugQuery, ProductDto>
    {
        private readonly ShopContext _context;
        public GetProductBySlugHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<ProductDto> Handle(GetProductBySlugQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p=>p.Slug == request.Slug,cancellationToken);

            if (product == null)
                  return null;

            var model = product.Map();

            await model.SetCateries(_context);
            return model;
        }
    }
}
