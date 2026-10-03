using Microsoft.EntityFrameworkCore;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Infrastructure._Utilities;
using Shop.Infrastructure.Persistent.Ef._Context;

namespace Shop.Infrastructure.Persistent.Ef.CategoryAgg
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ShopContext context) : base(context)
        {
        }

        public async Task<bool> DeleteCategory(long CategoryId)
        {
            var category = await _context.Categories
             .Include(c => c.Childs)
             .ThenInclude(c => c.Childs).FirstOrDefaultAsync(f => f.Id == CategoryId);

            if (category == null)
                return false;


            var isExistProduct = await _context.Products
                .AnyAsync(f => f.CategoryId == CategoryId ||
                               f.SubCategoryId == CategoryId ||
                               f.SecondarySubCategoryId == CategoryId);

            if (isExistProduct)
                return false;

            if (category.Childs.Any(c => c.Childs.Any()))
            {
                _context.RemoveRange(category.Childs.SelectMany(s => s.Childs));
            }
            _context.RemoveRange(category.Childs);
            _context.RemoveRange(category);
            return true;
        }
    }
}
