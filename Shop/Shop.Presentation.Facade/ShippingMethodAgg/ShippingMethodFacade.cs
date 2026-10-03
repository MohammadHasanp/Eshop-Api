using Common.Application;
using MediatR;
using Shop.Application.ShippingMethod.Create;
using Shop.Application.ShippingMethod.Delete;
using Shop.Application.ShippingMethod.Edit;
using Shop.Query.ShippingMethodAgg;
using Shop.Query.ShippingMethodAgg.GetById;
using Shop.Query.ShippingMethodAgg.GetList;

namespace Shop.Presentation.Facade.ShippingMethodAgg
{
    public class ShippingMethodFacade : IShippingMethodFacade
    {
        private readonly IMediator _mediator;
        public ShippingMethodFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> Create(CreateShippingMethodCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Delete(long Id)
        {
            return await _mediator.Send(new DeleteShippingMethodCommand(Id));
        }

        public async Task<OperationResult> Edit(EditShippingMethodCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<List<ShippingMethodDto>> GetAll()
        {
            return await _mediator.Send(new GetShippingMethodQuery());
        }

        public async Task<ShippingMethodDto> GetById(long Id)
        {
            return await _mediator.Send(new GetShippingMethoByIdQuery(Id));
        }
    }
}
