using Common.Application;
using Common.Domain.ValueObjects;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using System.Diagnostics.CodeAnalysis;

namespace Shop.Application.Users.EditAddress
{
    public class EditUserAddressCommand : IBaseCommand
    {
        public long UserId { get; internal set; }
        public long Id { get; set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public PhoneNumber Phone { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string NationalCode { get; private set; }

        public EditUserAddressCommand(long userId, string shire, string city, string postalCode, string postalAddress
            , PhoneNumber phone, string name, string family, string nationalCode)
        {
            UserId = userId;
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            Phone = phone;
            Name = name;
            Family = family;
            NationalCode = nationalCode;
        }
    }

    public class EditUserAddressCommandHandler : IBaseCommandHandler<EditUserAddressCommand>
    {
        private readonly IUserRepository _repository;

        public EditUserAddressCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(EditUserAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.UserId);
            
            if (user == null)
                return OperationResult.NotFound();
            var address = new UserAddress(request.Shire, request.City, request.PostalCode, request.PostalAddress, request.Phone, request.Name
                , request.Family, request.NationalCode);
            user.EditAddress(address,request.Id);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
