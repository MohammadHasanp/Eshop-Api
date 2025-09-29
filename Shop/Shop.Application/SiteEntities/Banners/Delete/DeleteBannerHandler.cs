
using Common.Application;
using Shop.Domain.SiteEntities.Repository;

namespace Shop.Application.SiteEntities.Banners.Delete
{
    public class DeleteBannerHandler : IBaseCommandHandler<DeleteBannerCommand>
    {
        private readonly IBannerRepository _repository;
        public DeleteBannerHandler(IBannerRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult> Handle(DeleteBannerCommand request, CancellationToken cancellationToken)
        {
            var banner = await _repository.GetTracking(request.BannerId);
            if (banner == null)
                return OperationResult.NotFound();

            _repository.Delete(banner);
            await _repository.Save();
            return OperationResult.Success();
            
        }
    }
}
