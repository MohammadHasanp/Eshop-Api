
using Common.Application;
using Shop.Domain.SiteEntities.Repository;

namespace Shop.Application.SiteEntities.Sliders.Delete
{
    public class DeleteSliderHandler : IBaseCommandHandler<DeleteSliderCommand>
    {
        private readonly ISliderRepository _repository;
        public DeleteSliderHandler(ISliderRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult> Handle(DeleteSliderCommand request, CancellationToken cancellationToken)
        {
            var slider = await _repository.GetTracking(request.SliderId);
            if (slider == null)
                return OperationResult.NotFound();

            _repository.Delete(slider);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
