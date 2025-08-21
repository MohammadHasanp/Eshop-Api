using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.RemoveImage
{
    public class RemoveProductImageCommandHandler : IBaseCommandHandler<RemoveProductImageCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IFileService _fileService;

        public RemoveProductImageCommandHandler(IProductRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(RemoveProductImageCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetTracking(request.productId);

            if (product == null)
                return OperationResult.NotFound();

            var imageName = product.RemoveImage(request.ImageId);
            _fileService.DeleteFile(Directories.ProductGalleryImages, imageName);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
