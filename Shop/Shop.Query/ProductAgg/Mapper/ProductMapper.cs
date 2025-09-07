using Microsoft.EntityFrameworkCore;
using Shop.Domain.ProductAgg;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.ProductAgg.DTOs;

namespace Shop.Query.ProductAgg.Mapper
{
    public static class ProductMapper
    {
        public static ProductDto Map(this Product product)
        {
            return new ProductDto()
            {
                CreationDate = product.CreationDate,
                Description = product.Description,
                Id = product.Id,
                ImageName = product.ImageName,
                SeoData = product.SeoData,
                Slug = product.Slug,
                Title = product.Title,
                Images = product.Images.Select(i => new ProductImageDto
                {
                    Id = i.Id,
                    CreationDate = i.CreationDate,
                    ImageName = i.ImageName,
                    ProductId = i.ProductId,
                    Sequence = i.Sequence,
                }).ToList(),
                Specifications = product.Specifications.Select(s => new ProductSpecificationDto()
                {
                    CreationDate = s.CreationDate,
                    Id = s.Id,
                    Key = s.Key,
                    Value = s.Value
                }).ToList(),
                Category = new ProductCategoryDto() { Id = product.CategoryId },

                SecondarySubCategory = product.SecondarySubCategoryId != null ?
                new ProductCategoryDto() { Id = (long)product.SecondarySubCategoryId } : null,

                SubCategory = new ProductCategoryDto() { Id = product.SubCategoryId },
            };
        }

        public static ProductFilterData MapFilterData(this Product product)
        {
            return new ProductFilterData()
            {
                CreationDate = product.CreationDate,
                Id = product.Id,
                ImageName = product.ImageName,
                Slug = product.Slug,
                Tilte = product.Title
            };
        }

        public static async Task SetCateries(this ProductDto product, ShopContext context)
        {
            var categories = await context.Categories.Where(c => c.Id == product.Category.Id || c.Id == product.SubCategory.Id)
                .Select(c => new ProductCategoryDto()
                {
                    Id = c.Id,
                    SeoData = c.SeoData,
                    ParentId = c.ParentId,
                    Slug = c.Slug,
                    Title = c.Title
                }).ToListAsync();

            if (product.SecondarySubCategory != null)
            {
                var secondarysubCategory = await context.Categories.Where(c => c.Id == product.SecondarySubCategory.Id)
                 .Select(c => new ProductCategoryDto()
                 {
                     Id = c.Id,
                     SeoData = c.SeoData,
                     ParentId = c.ParentId,
                     Slug = c.Slug,
                     Title = c.Title
                 }).FirstOrDefaultAsync();
                if (secondarysubCategory != null)
                {
                    product.SecondarySubCategory = secondarysubCategory;
                }
            }

            product.Category = categories.First(r => r.Id == product.Category.Id);
            product.SubCategory = categories.First(r => r.Id == product.SubCategory.Id);
        }
    }
}
