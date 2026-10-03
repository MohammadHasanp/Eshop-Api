using Common.Application;
using MediatR;
using Shop.Application.Products.AddImage;
using Shop.Application.Products.Create;
using Shop.Application.Products.Edit;
using Shop.Application.Products.RemoveImage;
using Shop.Presentation.Facade.SellerAgg.Inventory;
using Shop.Query.ProductAgg.DTOs;
using Shop.Query.ProductAgg.GetByFilter;
using Shop.Query.ProductAgg.GetById;
using Shop.Query.ProductAgg.GetBySlug;
using Shop.Query.ProductAgg.GetForShop;
using Shop.Query.SellerAgg.Inventory.GetByProductId;

namespace Shop.Presentation.Facade.ProductAgg
{
    public class ProductFacade : IProductFacade
    {
        private readonly IMediator _mediator;
        private readonly ISellerInventoryFacade _facade;
        public ProductFacade(IMediator mediator, ISellerInventoryFacade facade)
        {
            _mediator = mediator;
            _facade = facade;
        }
        public async Task<OperationResult> AddImage(AddProductImageCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Create(CreateProductCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DeleteImage(RemoveProductImageCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Edit(EditProductCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<ProductShopResult> GetForShop(ProductShopFilterParams @params)
        {
            return await _mediator.Send(new GetProductsForShopQuery(@params));
        }

        public async Task<ProductFilterResult> GetProductByFilter(ProductFilterParams @params)
        {
            return await _mediator.Send(new GetProductByFilterQuery(@params));
        }

        public async Task<ProductDto> GetProductById(long Id)
        {
            return await _mediator.Send(new GetProductByIdQuery(Id));
        }

        public async Task<ProductDto> GetProductBySlug(string Slug)
        {
            return await _mediator.Send(new GetProductBySlugQuery(Slug));
        }

        public async Task<SingleProductDto> GetProductBySlugForSinglePage(string slug)
        {
            var product = await _mediator.Send(new GetProductBySlugQuery(slug));
            if (product == null)
                return null;

            var inventories = await _facade.GetInventoryByProductId(product.Id);
            var model = new SingleProductDto()
            {
                Inventories = inventories,
                Product = product
            };
            return model;
        }
    }
}
