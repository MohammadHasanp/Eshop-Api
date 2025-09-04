
using Common.Application;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.RemoveToken
{
    public record RemoveUserTokenCommand(long UserId,long TokenId):IBaseCommand<string>;


    internal class RemoveUserTokenHandler : IBaseCommandHandler<RemoveUserTokenCommand, string>
    {
        private readonly IUserRepository _userRepository;

        public RemoveUserTokenHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult<string>> Handle(RemoveUserTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult<string>.NotFound();

            var token = user.RemoveToken(request.TokenId);
            await _userRepository.Save();
            return OperationResult<string>.Success(token);
        }
    }
}
