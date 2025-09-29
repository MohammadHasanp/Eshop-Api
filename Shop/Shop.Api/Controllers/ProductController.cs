using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.Api.ViewModel.Product;
using Shop.Application.Products.AddImage;
using Shop.Application.Products.Create;
using Shop.Application.Products.Edit;
using Shop.Application.Products.RemoveImage;
using Shop.Domain.RoleAgg.Enums;
using Shop.Presentation.Facade.ProductAgg;
using Shop.Query.ProductAgg.DTOs;

namespace Shop.Api.Controllers
{
    //[PermissionChecker(Permission.CRUD_Product)]
    public class ProductController : ApiController
    {
        private readonly IProductFacade _productFacade;
        public ProductController(IProductFacade productFacade)
        {
            _productFacade = productFacade;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ApiResult<ProductFilterResult>> GetProductByFilter([FromQuery] ProductFilterParams filterParams)
        {
            var result = await _productFacade.GetProductByFilter(filterParams);
            return QueryResult(result);
        }
        [AllowAnonymous]
        [HttpGet("ShopController")]
        public async Task<ApiResult<ProductShopResult>> GetProductForShopFilter([FromQuery] ProductShopFilterParams @params)
        {
            var result = await _productFacade.GetForShop(@params);
            return QueryResult(result);
        }
        [AllowAnonymous]
        [HttpGet("byId/{Id}")]
        public async Task<ApiResult<ProductDto>> GetProductById(long Id)
        {
            var result = await _productFacade.GetProductById(Id);
            return QueryResult(result);
        }
        [AllowAnonymous]
        [HttpGet("BySlug/{Slug}")]
        public async Task<ApiResult<ProductDto>> GetProductBySlug(string Slug)
        {
            var result = await _productFacade.GetProductBySlug(Slug);
            return QueryResult(result);
        }
        [HttpPost]
        public async Task<ApiResult> CreateProduct([FromForm] CreateProductViewModel viewModel)
        {
            var model = new CreateProductCommand(viewModel.Title, viewModel.ImageFile, viewModel.Description
                , viewModel.CategoryId, viewModel.SubCategoryId, viewModel.SecondarySubCategory, viewModel.Slug
                , viewModel.SeoData.MapToSeoData(), viewModel.GetSpecification());

            var result = await _productFacade.Create(model);
            return CommandResult(result);
        }
        [HttpPut]
        public async Task<ApiResult> EditProduct([FromForm] EditProductViewModel viewModel)
        {
            var model = new EditProductCommand(viewModel.ProductId, viewModel.Title, viewModel.ImageFile, viewModel.Description
                , viewModel.CategoryId, viewModel.SubCategoryId, viewModel.SecondarySubCategory, viewModel.Slug
                , viewModel.SeoData.MapToSeoData(), viewModel.GetSpecification());

            var result = await _productFacade.Edit(model);
            return CommandResult(result);
        }
        [HttpDelete("Image")]
        public async Task<ApiResult> DeleteProductImage(RemoveProductImageViewModel viewModel)
        {
            var model = new RemoveProductImageCommand(viewModel.productId,viewModel.ImageId);
            var result = await _productFacade.DeleteImage(model);
            return CommandResult(result);
        }
        [HttpPost("Image")]
        public async Task<ApiResult> AddImage(AddProductImageViewModel viewModel)
        {
            var model = new AddProductImageCommand(viewModel.ImageFile,viewModel.ProductId,viewModel.Sequence);
            var result = await _productFacade.AddImage(model);
            return CommandResult(result);
        }
        [HttpGet("Single{slug}")]
        public async Task<ApiResult<SingleProductDto>> GetSingleProduct(string slug)
        {
            var result = await _productFacade.GetProductBySlugForSinglePage(slug);
            return QueryResult(result);
        }
    }
}
