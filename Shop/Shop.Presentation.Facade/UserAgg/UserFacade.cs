using Common.Application;
using Common.Application.SecurityUtil;
using MediatR;
using Shop.Application.Users.AddToken;
using Shop.Application.Users.ChargeWallet;
using Shop.Application.Users.Create;
using Shop.Application.Users.Edit;
using Shop.Application.Users.Register;
using Shop.Application.Users.RemoveToken;
using Shop.Query.UserAgg.DTOs;
using Shop.Query.UserAgg.GetByEmail;
using Shop.Query.UserAgg.GetByFilter;
using Shop.Query.UserAgg.GetById;
using Shop.Query.UserAgg.GetByPhoneNumber;
using Shop.Query.UserAgg.GetList;
using Shop.Query.UserAgg.UserToken.GetByJwtToken;
using Shop.Query.UserAgg.UserToken.GetByRefreshToken;

namespace Shop.Presentation.Facade.UserAgg
{
    internal class UserFacade : IUserFacade
    {
        private readonly IMediator _mediator;
        public UserFacade(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<OperationResult> ChargeWallet(ChargeUserWalletCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Create(CreateUserCommand command)
        {
            return await _mediator.Send(command);
        }
        public async Task<OperationResult> Edit(EditUserCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<List<UserDto>> GetAllUser()
        {
            return await _mediator.Send(new GetAllUserQuery());
        }

        public async Task<UserDto> GetUserByPhoneNumber(string Phone)
        {
            return await _mediator.Send(new GetUserByPhoneNumberQuery(Phone));
        }

        public async Task<UserDto> GetUserByEmail(string email)
        {
            return await _mediator.Send(new GetUserByEmailqQery(email));
        }

        public async Task<UserFilterResult> GetUserByFilter(UserFilterParams @params)
        {
            return await _mediator.Send(new GetUserByFilterQuery(@params));
        }

        public async Task<UserDto> GetUserById(long Id)
        {
            return await _mediator.Send(new GetUserByIdQuery(Id));
        }

        public async Task<OperationResult> Register(RegisterUserCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> AddToken(AddUserTokenCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult<string>> RemoveToken(RemoveUserTokenCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<UserTokenDto?> GetUserTokenByRefreshToken(string refreshToken)
        {
            var hashRefreshToken = Sha256Hasher.Hash(refreshToken);
            return await _mediator.Send(new GetUserTokenByRefreshTokenQuery(hashRefreshToken));
        }

        public async Task<UserTokenDto?> GetUserTokenByJwtTokenQuery(string jwtToken)
        {
            var hashToken = Sha256Hasher.Hash(jwtToken);
            return await _mediator.Send(new GetUserTokenByJwtTokenQuery(hashToken));
        }
    }
}
