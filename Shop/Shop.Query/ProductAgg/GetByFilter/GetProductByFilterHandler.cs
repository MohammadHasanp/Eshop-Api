using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.ProductAgg.DTOs;
using Shop.Query.ProductAgg.Mapper;

namespace Shop.Query.ProductAgg.GetByFilter
{
    public class GetProductByFilterHandler : IQueryHandler<GetProductByFilterQuery, ProductFilterResult>
    {
        private readonly ShopContext _context;
        public GetProductByFilterHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<ProductFilterResult> Handle(GetProductByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var result = _context.Products.OrderByDescending(p=>p.Id).AsQueryable();
 
            if (@params.Id != null)
                result = result.Where(p=>p.Id == @params.Id);

            if (!string.IsNullOrWhiteSpace(@params.Title))
                result = result.Where(p => p.Title.Contains(@params.Title));

            if (!string.IsNullOrWhiteSpace(@params.Slug))
                result = result.Where(p => p.Slug == @params.Slug);

            var skip = (@params.PageId - 1) * @params.Take;
            var model = new ProductFilterResult()
            {
                Datas =await result.Skip(skip).Take(@params.Take).Select(p=>p.MapFilterData())
                .ToListAsync(cancellationToken),
                
                FilterParams = @params
            };
            model.GeneratePaging(result,@params.Take,@params.PageId);
            return model;
        }
    }
}
