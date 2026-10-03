using Common.Application;
using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repository;

namespace Shop.Application.ShippingMethod.Edit
{
    public record EditShippingMethodCommand(long Id, string Title, int Cost) : IBaseCommand;


    public class EditShippingMethodHandler : IBaseCommandHandler<EditShippingMethodCommand>
    {
        private readonly IShippingMethodRepository _repository;
        public EditShippingMethodHandler(IShippingMethodRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(EditShippingMethodCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetTracking(request.Id);
            if (result == null)
                return OperationResult.NotFound();

            result.Edit(request.Title, request.Cost);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
