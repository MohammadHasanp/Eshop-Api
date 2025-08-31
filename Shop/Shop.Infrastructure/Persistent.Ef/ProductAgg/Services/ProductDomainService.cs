using Shop.Domain.ProductAgg.DomainServices;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Infrastructure.Persistent.Ef.ProductAgg.Services
{
    public class ProductDomainService : IProductDomainService
    {
        private readonly IProductRepository _repository;
        public ProductDomainService(IProductRepository repository)
        {
            _repository = repository;
        }
        public bool IsExistSlug(string slug)
        {
            return _repository.Exists(c=>c.Slug == slug);
        }
    }
}
