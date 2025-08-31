using Common.Application;
using MediatR;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.DeleteAddress;
using Shop.Application.Users.EditAddress;

namespace Shop.Presentation.Facade.UserAgg.UserAddress
{
    internal class UserAddressFacade : IUserAddressFacade
    {
        private readonly IMediator _mediator;
        public UserAddressFacade(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<OperationResult> AddUserAddress(AddUserAddressCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DeleteUserAddress(DeleteUserAddressCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditUserAddress(EditUserAddressCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
