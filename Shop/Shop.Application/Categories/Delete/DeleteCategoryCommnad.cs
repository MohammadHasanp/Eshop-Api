using Common.Application;
using Shop.Domain.CategoryAgg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Categories.Delete
{
    public record DeleteCategoryCommnad(long CategoryId):IBaseCommand;

    public class DeleteCategoryHandler : IBaseCommandHandler<DeleteCategoryCommnad>
    {
        private readonly ICategoryRepository _repository;
        public DeleteCategoryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult> Handle(DeleteCategoryCommnad request, CancellationToken cancellationToken)
        {
            var result = await _repository.DeleteCategory(request.CategoryId);
            if (result)
            {
                await _repository.Save();
                return OperationResult.Success();
            }
            return OperationResult.Error("امکان حذف این دسته بندی وجود ندارد");
        }
    }
}
