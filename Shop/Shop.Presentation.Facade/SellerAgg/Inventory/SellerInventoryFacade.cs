using Common.Application;
using MediatR;
using Shop.Application.Sellers.AddInventory;
using Shop.Application.Sellers.EditInventory;
using Shop.Query.SellerAgg.DTOs;
using Shop.Query.SellerAgg.Inventory.GetById;
using Shop.Query.SellerAgg.Inventory.GetList;

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

        public Task<List<SellerInventoryDto>> GetAll(long SellerId)
        {
            return _mediator.Send(new GetAllSellerInventoryBySellerIdQuery(SellerId));
        }

        public async Task<SellerInventoryDto?> GetById(long InventoriId)
        {
            return await _mediator.Send(new GetSellerInventoryByIdQuery(InventoriId));
        }
    }
}
