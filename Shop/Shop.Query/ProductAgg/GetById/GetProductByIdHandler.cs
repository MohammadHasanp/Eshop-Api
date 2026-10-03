using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.ProductAgg.DTOs;
using Shop.Query.ProductAgg.Mapper;

namespace Shop.Query.ProductAgg.GetById
{
    public class GetProductByIdHandler : IQueryHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly ShopContext _context;
        public GetProductByIdHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.ProductId, cancellationToken);
          
             if (product == null)
                   return null;

            var model = product.Map();
            await model.SetCateries(_context);
            return model;
        }
    }
}
