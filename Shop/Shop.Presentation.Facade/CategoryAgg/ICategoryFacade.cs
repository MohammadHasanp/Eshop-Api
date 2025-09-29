using Common.Application;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Delete;
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
        Task<OperationResult<long>> Addchilld(AddChildCategoryCommand command);
        Task<OperationResult<long>> Create(CreateCategoryCommand command);
        Task<OperationResult> Edit(EditCategoryCommand command);
        Task<OperationResult> Delete(long categoryId);

        Task<CategoryDto> GetCategoryById(long Id);
        Task<List<SubCategoryDto>>GetCategoryByParentId(long parentId);

        Task<List<CategoryDto>> GetAllCategory();
    }
}
