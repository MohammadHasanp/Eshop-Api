using Common.Application;
using Shop.Application.Users.AddToken;
using Shop.Application.Users.ChargeWallet;
using Shop.Application.Users.Create;
using Shop.Application.Users.Edit;
using Shop.Application.Users.Register;
using Shop.Application.Users.RemoveToken;
using Shop.Query.UserAgg.DTOs;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.UserAgg
{
    public interface IUserFacade
    {
        Task<OperationResult> Create(CreateUserCommand command);
        Task<OperationResult> Edit(EditUserCommand command);
        Task<OperationResult> Register(RegisterUserCommand command);
        Task<OperationResult> ChargeWallet(ChargeUserWalletCommand command);
        Task<OperationResult> AddToken(AddUserTokenCommand command);
        Task<OperationResult<string>> RemoveToken(RemoveUserTokenCommand command);

        Task<UserDto>GetUserByEmail(string email);
        Task<UserTokenDto?> GetUserTokenByRefreshToken(string refreshToken);
        Task<UserTokenDto?> GetUserTokenByJwtTokenQuery(string jwtToken);
        Task<UserFilterResult> GetUserByFilter(UserFilterParams @params);
        Task<UserDto> GetUserById(long Id);
        Task<UserDto> GetUserByPhoneNumber(string Phone);
        Task<List<UserDto>> GetAllUser();
    }
}
