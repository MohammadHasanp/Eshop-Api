using Shop.Domain.CategoryAgg;
using Shop.Query.CategoryAgg.DTOs;
using System.Runtime.CompilerServices;

namespace Shop.Query.CategoryAgg.Mapper
{
    public static class CategoryMapper
    {
        public static CategoryDto Map(this Category? category)
        {
            if (category == null)
                return null;

            return new CategoryDto()
            {
                Id = category.Id,
                Title = category.Title,
                SeoData = category.SeoData,
                Slug = category.Slug,
                CreationDate = category.CreationDate,
                Childs = category.Childs.MapChildren()
            };
        }
        public static List<CategoryDto> Map(this List<Category> categories)
        {
            var model = new List<CategoryDto>();
            categories.ForEach(category =>
            {
                model.Add(new CategoryDto()
                {
                    Title = category.Title,
                    Slug = category.Slug,
                    Id = category.Id,
                    SeoData = category.SeoData,
                    CreationDate = category.CreationDate,
                    Childs = category.Childs.MapChildren()
                });
            });
            return model;
        }

        public static List<SubCategoryDto> MapChildren(this List<Category> children)
        {
            var model = new List<SubCategoryDto>();
            children.ForEach(c =>
            {
                model.Add(new SubCategoryDto
                {

                    Id = c.Id,
                    Title = c.Title,
                    SeoData = c.SeoData,
                    Slug = c.Slug,
                    CreationDate = c.CreationDate,
                    Childs = c.Childs.MapSecondryChild()
                });
            });
            return model;
        }

        public static List<SecondaryChildCategoryDto> MapSecondryChild(this List<Category> children)
        {
            var model = new List<SecondaryChildCategoryDto>();
            children.ForEach(c =>
            {
                model.Add(new SecondaryChildCategoryDto()
                {
                    Id = c.Id,
                    Title = c.Title,
                    SeoData = c.SeoData,
                    Slug = c.Slug,
                    CreationDate = c.CreationDate,
                });
            });
            return model;
        }
    }
}
