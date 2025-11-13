using Common.Application;
using Shop.Domain.SiteEntities.Repository;

namespace Shop.Application.ShippingMethod.Delete
{
    public record DeleteShippingMethodCommand(long ShippingMethodId):IBaseCommand;

    public class DeleteShippingMethodHandler : IBaseCommandHandler<DeleteShippingMethodCommand>
    {
        private readonly IShippingMethodRepository _repository;
        public DeleteShippingMethodHandler(IShippingMethodRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(DeleteShippingMethodCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetTracking(request.ShippingMethodId);
            if (result == null)
                return OperationResult.NotFound();

             _repository.Delete(result);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
