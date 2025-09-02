using AngleSharp.Dom;
using Common.Application;
using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Presentation.Facade.CategoryAgg;
using Shop.Query.CategoryAgg.DTOs;
using System.Net;

namespace Shop.Api.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryFacade _category;
        public CategoryController(ICategoryFacade category)
        {
            _category = category;
        }
        [HttpGet]
        public async Task<ApiResult<List<CategoryDto>>> GetCategories()
        {
            var result = await _category.GetAllCategory();
            return QueryResult(result);
        }
        [HttpGet("{id}")]
        public async Task<ApiResult<CategoryDto>> GetCategoryById(long id)
        {
            var result = await _category.GetCategoryById(id);
            return QueryResult(result);
        }
        [HttpGet("getchild/{ParentId}")]
        public async Task<ApiResult<List<SubCategoryDto>>> GetCategoriesByParentId(int perntId)
        {
            var result = await _category.GetCategoryByParentId(perntId);
            return QueryResult(result);
        }
        [HttpPost]
        public async Task<ApiResult<long>> CreateCategory(CreateCategoryCommand command)
        {
            var result = await _category.Create(command);
            var url = Url.Action("GetCategoryById", "Category", new {Id =result.Data},Request.Scheme);
            return CommandResult(result,HttpStatusCode.Created,url);
        }
        [HttpPost("Addchild")]
        public async Task<ApiResult<long>> CreateCategory(AddChildCategoryCommand command)
        {
            var result = await _category.Addchilld(command);
            var url = Url.Action("GetCategoryById", "Category", new {Id = result.Data },Request.Scheme);
            return CommandResult(result,HttpStatusCode.Created,url);
        }
        [HttpPut]
        public async Task<ApiResult> EditCategory(EditCategoryCommand command)
        {
            var result = await _category.Edit(command);
            return CommandResult(result);
        }
        [HttpDelete("{categoryID}")]
        public async Task<ApiResult> DeleteCategory(long categoryID)
        {
            var result = await _category.Delete(categoryID);
            return CommandResult(result);
        }
    }
}