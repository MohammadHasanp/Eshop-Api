using Common.Application;
using Common.Application.SecurityUtil;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.Register
{
    public class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand>
    {
        private readonly IUserDomainService _domainService;
        private readonly IUserRepository _repository;

        public RegisterUserCommandHandler(IUserDomainService domainService, IUserRepository repository)
        {
            _domainService = domainService;
            _repository = repository;
        }

        public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = User.RegisterUser(Sha256Hasher.Hash(request.Password), request.Phone.Value, _domainService);
            _repository.Add(user);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
