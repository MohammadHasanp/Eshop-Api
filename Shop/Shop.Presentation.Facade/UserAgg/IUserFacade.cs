using Common.Application;
using Shop.Application.Users.ChargeWallet;
using Shop.Application.Users.Create;
using Shop.Application.Users.Edit;
using Shop.Application.Users.Register;
using Shop.Query.UserAgg.DTOs;

namespace Shop.Presentation.Facade.UserAgg
{
    internal interface IUserFacade
    {
        Task<OperationResult> Create(CreateUserCommand command);
        Task<OperationResult> Edit(EditUserCommand command);
        Task<OperationResult> Register(RegisterUserCommand command);
        Task<OperationResult> ChargeWallet(ChargeUserWalletCommand command);



        Task<UserDto>GetUserByEmail(string email);
        Task<UserFilterResult> GetUserByFilter(UserFilterParams @params);
        Task<UserDto> GetUserById(long Id);
        Task<UserDto> GetByPhoneNumber(string Phone);
        Task<List<UserDto>> GetAllUser();
    }
}
