using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repository;

namespace Shop.Application.SiteEntities.Sliders.Create
{
    public class CreateSliderCommandHandler : IBaseCommandHandler<CreateSliderCommand>
    {
        private readonly ISliderRepository _repository;
        private readonly IFileService _fileService;

        public CreateSliderCommandHandler(ISliderRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
        {
            var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile,Directories.SliderImages); 
            var slider = new Slider(request.Title,request.Link,imageName);
            await _repository.AddAsync(slider);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
