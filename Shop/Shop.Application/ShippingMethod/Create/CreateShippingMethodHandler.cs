using Common.Application;
using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repository;

namespace Shop.Application.ShippingMethod.Create
{
    public class CreateShippingMethodHandler : IBaseCommandHandler<CreateShippingMethodCommand>
    {
        private readonly IShippingMethodRepository _repository;
        public CreateShippingMethodHandler(IShippingMethodRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CreateShippingMethodCommand request, CancellationToken cancellationToken)
        {
            _repository.Add(new ShippingMothod(request.Title,request.Cost));
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
