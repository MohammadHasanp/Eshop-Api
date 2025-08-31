using Common.Application;
using MediatR;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Query.CategoryAgg.DTOs;
using Shop.Query.CategoryAgg.GetById;
using Shop.Query.CategoryAgg.GetByParentId;
using Shop.Query.CategoryAgg.GetList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.CategoryAgg
{
    internal class CategoryFacade : ICategoryFacade
    {
        private readonly IMediator _mediator;
        public CategoryFacade(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<OperationResult> Addchilld(AddChildCategoryCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Create(CreateCategoryCommand command)
        {
            return await _mediator.Send(command);
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

        public async Task<List<SubCategoryDto>> GetCategoryByParentId(int parentId)
        {
            return await _mediator.Send(new GetCategoryByParentIdQuery(parentId));
        }
    }
}
