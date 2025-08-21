using Common.Application;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Application.Sellers.Create
{
    public class CreateSellerCommandHandler : IBaseCommandHandler<CreateSellerCommand>
    {
        private readonly ISellerDomainService _domainService;
        private readonly ISellerRepository _repository;
        public CreateSellerCommandHandler(ISellerRepository repository, ISellerDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
        {
            var seller = new Seller(request.UserId,request.ShopName,request.NationalCode,_domainService);
            await _repository.AddAsync(seller);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
