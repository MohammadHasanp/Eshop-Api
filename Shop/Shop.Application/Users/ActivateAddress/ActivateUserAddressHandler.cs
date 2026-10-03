
using Common.Application;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.ActivateAddress
{
    public class ActivateUserAddressHandler : IBaseCommandHandler<ActivateUserAddressCommand>
    {
        private readonly IUserRepository _repository;
        public ActivateUserAddressHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult> Handle(ActivateUserAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();

            user.SetActiveAddress(request.AddressId);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
