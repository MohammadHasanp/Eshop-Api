using Common.Application;
using MediatR;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Categories.Create
{
    public class CreateCategoryCommandHandler : IBaseCommandHandler<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryDomainServices _domainService;

        public CreateCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainServices domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.title, request.slug, request.SeoData, _domainService);
            await _repository.Add(category);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
