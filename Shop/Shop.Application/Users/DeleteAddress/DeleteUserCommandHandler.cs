using Common.Application;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.DeleteAddress
{
    public class DeleteUserCommandHandler : IBaseCommandHandler<DeleteUserCommand>
    {
        private readonly IUserDomainService _domainService;
        private readonly IUserRepository _repository;

        public DeleteUserCommandHandler(IUserDomainService domainService, IUserRepository repository)
        {
            _domainService = domainService;
            _repository = repository;
        }

        public async Task<OperationResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.AddressId);

            if (user == null)
                return OperationResult.NotFound();

            user.DeleteAddress(request.AddressId);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
