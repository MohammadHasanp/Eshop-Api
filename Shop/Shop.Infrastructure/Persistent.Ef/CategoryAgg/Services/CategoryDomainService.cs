using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.CategoryAgg.Services
{
    public class CategoryDomainService : ICategoryDomainServices
    {
        private readonly ICategoryRepository _repository;
        public CategoryDomainService(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public bool IsExistSlug(string slug)
        {
            return _repository.Exists(c=>c.Slug == slug);
        }
    }
}
