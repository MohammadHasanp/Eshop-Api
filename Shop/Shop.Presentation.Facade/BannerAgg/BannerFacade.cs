using Common.Application;
using MediatR;
using Shop.Application.SiteEntities.Banners.Create;
using Shop.Application.SiteEntities.Banners.Edit;
using Shop.Query.BannerAgg.DTOs;
using Shop.Query.BannerAgg.GetById;
using Shop.Query.BannerAgg.GetList;

namespace Shop.Presentation.Facade.BannerAgg
{
    public class BannerFacade : IBannerFacade
    {
        private readonly IMediator _mediator;
        public BannerFacade(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<OperationResult> Create(CreateBannerCommand command)
        {
            return await _mediator.Send(command);
        }
        public async Task<OperationResult> Edit(EditBannerCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<List<BannerDto>> GetAllBanner()
        {
            return await _mediator.Send(new GetAllBannerQuery());
        }

        public async Task<BannerDto> GetBannerById(long Id)
        {
            return await _mediator.Send(new GetBannerByIdQuery(Id));
        }
    }
}
