using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Repository;

namespace Shop.Application.SiteEntities.Sliders.Edit
{
    public class EditSliderCommandHandler : IBaseCommandHandler<EditSliderCommand>
    {
        private readonly ISliderRepository _repository;
        private readonly IFileService _fileService;

        public EditSliderCommandHandler(ISliderRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(EditSliderCommand request, CancellationToken cancellationToken)
        {
            var slider = await _repository.GetTracking(request.SliderId);

            if (slider == null)
                return OperationResult.NotFound();

            var imageName = slider.ImageName;
            var oldImage = slider.ImageName;
            if (request.ImageFile != null)
                imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.SliderImages);

            slider.Edit(request.Title, request.Link, imageName);
            await _repository.Save();
            RemoveOldImage(request.ImageFile,oldImage);
            return OperationResult.Success();
        }
        private void RemoveOldImage(IFormFile? file,string imageName)
        {
            if (file != null)
                _fileService.DeleteFile(Directories.SliderImages,imageName);
        }
    }

}
