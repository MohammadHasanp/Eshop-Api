using Common.Application;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories.AddChild
{
    public class AddChildCategoryHandler : IBaseCommandHandler<AddChildCategoryCommand,long>
    {
        private readonly ICategoryDomainServices _domainService;
        private readonly ICategoryRepository _repository;

        public AddChildCategoryHandler(ICategoryDomainServices domainService, ICategoryRepository repository)
        {
            _domainService = domainService;
            _repository = repository;
        }

        public async Task<OperationResult<long>> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetTracking(request.ParentId);

            if (category == null)
                return OperationResult<long>.NotFound();

            category.AddChild(request.Title, request.Slug, request.SeoData, _domainService);
            await _repository.Save();
            return OperationResult<long>.Success(category.Id);
        }
    }
}