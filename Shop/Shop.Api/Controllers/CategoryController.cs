using Common.AspNetCore;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.Api.ViewModel.Category;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Domain.RoleAgg.Enums;
using Shop.Presentation.Facade.CategoryAgg;
using Shop.Query.CategoryAgg.DTOs;
using System.Net;

namespace Shop.Api.Controllers
{
    //[PermissionChecker(Permission.Category_Management)]
    public class CategoryController : ApiController
    {
        private readonly ICategoryFacade _category;
        public CategoryController(ICategoryFacade category)
        {
            _category = category;
        }
        [AllowAnonymous]
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
        [HttpGet("GetChild/{perntId}")]
        public async Task<ApiResult<List<SubCategoryDto>>> GetCategoriesByParentId(long perntId)
        {
            var result = await _category.GetCategoryByParentId(perntId);
            return QueryResult(result);
        }
        [HttpPost]
        public async Task<ApiResult<long>> CreateCategory(CreateCategoryViewModel viewModel)
        {
            var model = new CreateCategoryCommand(viewModel.Title, viewModel.Slug
                , new SeoData(viewModel.SeoData.MetaTitle, viewModel.SeoData.MetaDescription
                , viewModel.SeoData.MetaKeyWords, viewModel.SeoData.IndexPage, viewModel.SeoData.Canonical
                , viewModel.SeoData.Schema));

            var result = await _category.Create(model);
            var url = Url.Action("GetCategoryById", "Category", new { Id = result.Data }, Request.Scheme);
            return CommandResult(result, HttpStatusCode.Created, url);
        }
        [HttpPost("AddChild")]
        public async Task<ApiResult<long>> CreateChildCategory(AddChildCategoryViewModel viewModel)
        {
            var model = new AddChildCategoryCommand(viewModel.ParentId, viewModel.Title, viewModel.Slug
                , new SeoData(viewModel.SeoData.MetaTitle, viewModel.SeoData.MetaDescription
                , viewModel.SeoData.MetaKeyWords, viewModel.SeoData.IndexPage, viewModel.SeoData.Canonical
                , viewModel.SeoData.Schema));

            var result = await _category.Addchilld(model);
            var url = Url.Action("GetCategoryById", "Category", new { Id = result.Data }, Request.Scheme);
            return CommandResult(result, HttpStatusCode.Created, url!);
        }
        [HttpPut]
        public async Task<ApiResult> EditCategory(EditCategoryViewModel viewModel)
        {
            var model = new EditCategoryCommand(viewModel.Id, viewModel.Title, viewModel.Slug
                  , new SeoData(viewModel.SeoData.MetaTitle, viewModel.SeoData.MetaDescription
                  , viewModel.SeoData.MetaKeyWords, viewModel.SeoData.IndexPage, viewModel.SeoData.Canonical
                  , viewModel.SeoData.Schema));

            var result = await _category.Edit(model);
            return CommandResult(result);
        }
        [HttpDelete("{categoryId}")]
        public async Task<ApiResult> DeleteCategory(long categoryId)
        {
            var result = await _category.Delete(categoryId);
            return CommandResult(result);
        }
    }
}