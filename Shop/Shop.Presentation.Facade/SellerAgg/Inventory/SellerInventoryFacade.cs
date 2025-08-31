using Common.Application;
using MediatR;
using Shop.Application.Sellers.AddInventory;
using Shop.Application.Sellers.EditInventory;

namespace Shop.Presentation.Facade.SellerAgg.Inventory
{
    public class SellerInventoryFacade : ISellerInventoryFacade
    {
        private readonly IMediator _mediator;
        public SellerInventoryFacade(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<OperationResult> Add(AddSellerInventoryCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Edit(EditSellerInaventoryCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
