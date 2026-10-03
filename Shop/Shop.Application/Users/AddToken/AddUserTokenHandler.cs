using Common.Application;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.AddToken
{
    public partial class AddUserTokenCommand
    {
        public class AddUserTokenHandler : IBaseCommandHandler<AddUserTokenCommand>
        {
            private readonly IUserRepository _userRepository;
            public AddUserTokenHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }
            public async Task<OperationResult> Handle(AddUserTokenCommand request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetTracking(request.UserId);
                if (user == null)
                    return OperationResult.NotFound();


                user.AddToken(request.HashJwtToken, request.HashRefreshToken, request.TokenExpireDate, request.RefreshTokenExpireDate, request.Device);
                await _userRepository.Save();
                return OperationResult.Success();
            }
        }
    }
}
