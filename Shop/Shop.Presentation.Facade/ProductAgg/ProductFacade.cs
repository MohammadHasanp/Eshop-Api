using Common.Application;
using MediatR;
using Shop.Application.Products.AddImage;
using Shop.Application.Products.Create;
using Shop.Application.Products.Edit;
using Shop.Application.Products.RemoveImage;
using Shop.Query.ProductAgg.DTOs;
using Shop.Query.ProductAgg.GetByFilter;
using Shop.Query.ProductAgg.GetById;
using Shop.Query.ProductAgg.GetBySlug;

namespace Shop.Presentation.Facade.ProductAgg
{
    public class ProductFacade : IProductFacade
    {
        private readonly IMediator _mediator;
        public ProductFacade(IMediator mediator)
        {
            _mediator = mediator;
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
    }
}
