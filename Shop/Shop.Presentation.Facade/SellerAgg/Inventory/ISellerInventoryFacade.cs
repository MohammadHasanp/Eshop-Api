using Common.Application;
using Shop.Application.Sellers.AddInventory;
using Shop.Application.Sellers.EditInventory;
using Shop.Query.SellerAgg.DTOs;

namespace Shop.Presentation.Facade.SellerAgg.Inventory
{
    public interface ISellerInventoryFacade
    {
        Task<OperationResult> Add(AddSellerInventoryCommand command);
        Task<OperationResult> Edit(EditSellerInaventoryCommand command);
        Task<SellerInventoryDto> GetById(long InventoriId);
        Task<List<SellerInventoryDto>> GetAll(long SellerId);
        Task<List<SellerInventoryDto>> GetInventoryByProductId(long productId);
    }
}
