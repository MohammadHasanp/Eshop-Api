using Common.Application;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Query.CategoryAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.CategoryAgg
{
    public interface ICategoryFacade
    {
        Task<OperationResult> Addchilld(AddChildCategoryCommand command);
        Task<OperationResult> Create(CreateCategoryCommand command);
        Task<OperationResult> Edit(EditCategoryCommand command);

        Task<CategoryDto> GetCategoryById(long Id);
        Task<List<SubCategoryDto>>GetCategoryByParentId(int parentId);

        Task<List<CategoryDto>> GetAllCategory();
    }
}
