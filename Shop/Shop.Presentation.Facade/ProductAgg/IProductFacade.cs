using Common.Application;
using Shop.Application.Products.AddImage;
using Shop.Application.Products.Create;
using Shop.Application.Products.Edit;
using Shop.Application.Products.RemoveImage;
using Shop.Query.ProductAgg.DTOs;
using Shop.Query.SellerAgg.DTOs;

namespace Shop.Presentation.Facade.ProductAgg
{
    public interface IProductFacade
    {
        Task<OperationResult> Create(CreateProductCommand command);
        Task<OperationResult> Edit(EditProductCommand command);
        Task<OperationResult> DeleteImage(RemoveProductImageCommand command);
        Task<OperationResult> AddImage(AddProductImageCommand command);


        Task<ProductShopResult> GetForShop(ProductShopFilterParams @params);
        Task<ProductDto> GetProductById(long Id);
        Task<ProductDto> GetProductBySlug(string Slug);
        Task<ProductFilterResult>GetProductByFilter(ProductFilterParams @params);
        Task<SingleProductDto> GetProductBySlugForSinglePage(string slug);
    }
    public class SingleProductDto()
    {
        public ProductDto Product { get; set; }
        public List<SellerInventoryDto> Inventories { get; set; }
    }
}
