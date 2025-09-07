using Common.Application;
using Shop.Application.Products.AddImage;
using Shop.Application.Products.Create;
using Shop.Application.Products.Edit;
using Shop.Application.Products.RemoveImage;
using Shop.Query.ProductAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

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
        Task<ProductFilterResult> GetProductByFilter(ProductFilterParams @params);
    }
}
