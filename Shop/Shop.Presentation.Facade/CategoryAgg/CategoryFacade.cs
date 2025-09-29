using Common.Application;
using MediatR;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Delete;
using Shop.Application.Categories.Edit;
using Shop.Query.CategoryAgg.DTOs;
using Shop.Query.CategoryAgg.GetById;
using Shop.Query.CategoryAgg.GetByParentId;
using Shop.Query.CategoryAgg.GetList;

namespace Shop.Presentation.Facade.CategoryAgg
{
    internal class CategoryFacade : ICategoryFacade
    {
        private readonly IMediator _mediator;
        public CategoryFacade(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<OperationResult<long>> Addchilld(AddChildCategoryCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult<long>> Create(CreateCategoryCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Delete(long categoryId)
        {
            return await _mediator.Send(new DeleteCategoryCommnad(categoryId));
        }

        public async Task<OperationResult> Edit(EditCategoryCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<List<CategoryDto>> GetAllCategory()
        {
            return await _mediator.Send(new GetCategoryListQuery());
        }

        public async Task<CategoryDto> GetCategoryById(long Id)
        {
            return await _mediator.Send(new GetCategoryByIdQuery(Id));
        }

        public async Task<List<SubCategoryDto>> GetCategoryByParentId(long parentId)
        {
            return await _mediator.Send(new GetCategoryByParentIdQuery(parentId));
        }
    }
}
