using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.DomainServices;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Products.Edit
{
    public class EditProductCommandHandler : IBaseCommandHandler<EditProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IProductService _productService;
        private readonly IFileService _fileService;

        public EditProductCommandHandler(IProductRepository repository, IProductService productService, IFileService fileService)
        {
            _repository = repository;
            _productService = productService;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetTracking(request.ProductId);

            if (product == null)
                return OperationResult.NotFound();

            product.Edit(request.Title,request.Description,request.CategoryId,request.SubCategoryId,
                request.SecondarySubCategory,request.Slug,request.SeoData,_productService);

            var oldImageName = product.ImageName;
             
            if(request.ImageFile != null)
            {
                var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile,Directories.ProductImages);
                product.SetImageProduct(imageName);
            }

            var listSpecification = new List<ProductSpecification>();

            request.Specifications.ToList().ForEach(specification =>
            {
                listSpecification.Add(new ProductSpecification(specification.Key,specification.Value));
            });
            product.SetSpecification(listSpecification);
            await _repository.Save();
            RemoveOldImage(request.ImageFile,oldImageName);
            return OperationResult.Success();
        }
        private void RemoveOldImage(IFormFile? file,string oldImageName)
        {
            if(file != null)
            {
                _fileService.DeleteFile(Directories.ProductImages,oldImageName);
            }
        }
    }
}
