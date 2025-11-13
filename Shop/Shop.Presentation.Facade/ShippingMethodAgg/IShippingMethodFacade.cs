using Common.Application;
using Shop.Application.ShippingMethod.Create;
using Shop.Application.ShippingMethod.Edit;
using Shop.Query.ShippingMethodAgg;

namespace Shop.Presentation.Facade.ShippingMethodAgg
{
    public interface IShippingMethodFacade
    {
        Task<OperationResult> Create(CreateShippingMethodCommand command);
        Task<OperationResult> Edit(EditShippingMethodCommand command);
        Task<OperationResult> Delete(long Id);


        Task<List<ShippingMethodDto>> GetAll();
        Task<ShippingMethodDto> GetById(long Id);
    }
}
