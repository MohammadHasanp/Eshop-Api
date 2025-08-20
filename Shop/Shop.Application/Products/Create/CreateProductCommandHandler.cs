using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.DomainServices;
using Shop.Domain.ProductAgg.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.Create
{
    public class CreateProductCommandHandler : IBaseCommandHandler<CreateProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IProductService _productService;
        private readonly IFileService _fileService;

        public CreateProductCommandHandler(IProductRepository repository, IProductService productService, IFileService fileService)
        {
            _repository = repository;
            _productService = productService;
            _fileService = fileService;
        }
        public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);

            var product = new Product(request.Title, imageName, request.Description, request.CategoryId,
                request.SubCategoryId, request.SecondarySubCategory, request.Slug, request.SeoData,
                _productService);

            await _repository.Add(product);

            var listSpecifications = new List<ProductSpecification>();

            request.Specifications.ToList().ForEach(specification =>
            {
                listSpecifications.Add(new ProductSpecification(specification.Key, specification.Value));
            });

            product.SetSpecification(listSpecifications);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
