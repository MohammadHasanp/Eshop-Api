using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.AddAddress
{
    public class AddUserAddressCommandHandler : IBaseCommandHandler<AddUserAddressCommand>
    {
        private readonly IUserDomainService _domainService;
        private readonly IUserRepository _repository;

        public AddUserAddressCommandHandler(IUserDomainService domainService, IUserRepository repository)
        {
            _domainService = domainService;
            _repository = repository;
        }

        public async Task<OperationResult> Handle(AddUserAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.UserId);

            if (user == null)
                return OperationResult.NotFound();

            var address = new UserAddress(request.Shire, request.City, request.PostalAddress, request.PostalAddress, request.Phone
                , request.Name, request.Family, request.NationalCode);

            user.AddAddress(address);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
