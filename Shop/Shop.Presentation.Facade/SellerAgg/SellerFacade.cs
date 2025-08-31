using Common.Application;
using MediatR;
using Shop.Application.Sellers.Create;
using Shop.Application.Sellers.Edit;
using Shop.Query.SellerAgg.DTOs;
using Shop.Query.SellerAgg.GetByFilter;
using Shop.Query.SellerAgg.GetById;

namespace Shop.Presentation.Facade.SellerAgg
{
    public class SellerFacade : ISellerFacade
    {
        private readonly IMediator _mediator;
        public SellerFacade(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<OperationResult> Create(CreateSellerCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Edit(EditSellerCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<SellerFilterResult> GetSellerByFilter(SellerFilterParams @params)
        {
            return await _mediator.Send(new GetSellerByFilterQuery(@params));
        }

        public async Task<SellerDto> GetSellerById(long Id)
        {
            return await _mediator.Send(new GetSellerByIdQuery(Id));
        }
    }
}
