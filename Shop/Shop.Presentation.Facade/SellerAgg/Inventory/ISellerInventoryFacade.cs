using Common.Application;
using Shop.Application.Sellers.AddInventory;
using Shop.Application.Sellers.EditInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.SellerAgg.Inventory
{
    public interface ISellerInventoryFacade
    {
        Task<OperationResult> Add(AddSellerInventoryCommand command);
        Task<OperationResult> Edit(EditSellerInaventoryCommand command);
    }
}
