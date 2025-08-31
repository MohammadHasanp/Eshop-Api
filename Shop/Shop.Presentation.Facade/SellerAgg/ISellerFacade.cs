using Common.Application;
using Shop.Application.Sellers.Create;
using Shop.Application.Sellers.Edit;
using Shop.Query.SellerAgg.DTOs;

namespace Shop.Presentation.Facade.SellerAgg
{
    public interface ISellerFacade
    {
        Task<OperationResult> Create(CreateSellerCommand command);
        Task<OperationResult> Edit(EditSellerCommand command);
        Task<SellerDto> GetSellerById(long Id);
        Task<SellerFilterResult> GetSellerByFilter(SellerFilterParams @params);
    }
}
