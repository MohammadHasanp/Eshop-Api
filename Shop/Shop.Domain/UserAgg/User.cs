using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Services;
using System.Diagnostics.Contracts;
using static Common.Domain.Exceptions.BaseDomainExceotion;

namespace Shop.Domain.UserAgg
{
    public class User : AggregateRoot
    {
        private User() { }
        //UserNAme User
        public string UserName { get; private set; }
        //FullName User
        public string FullName { get; private set; }
        public string AvatarName { get; private set; }
        //Password User
        public string Password { get; set; }
        //Email User
        public string Email { get; private set; }
        //Active User
        public bool IsActive { get; set; }
        //Password Phone
        public string PhoneNumber { get; private set; }
        //Gender User
        public Gender Gender { get; private set; }
        //Relation With UserRole
        public List<UserRole> Roles { get; private set; }
        //Relation With Wallet User
        public List<Wallet> Wallets { get; private set; }
        //Relation With User Address
        public List<UserAddress> Addresses { get; private set; }
        public List<UserToken> Tokens { get; private set; }

        //Set User
        public User(string userName, string fullName, string password, string email, string phoneNumber
            , Gender gender, IUserDomainService domainUserService)
        {
            Guard(phoneNumber, email, domainUserService);
            UserName = userName;
            FullName = fullName;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
            Gender = gender;
            Roles = new List<UserRole>();
            Wallets = new List<Wallet>();
            Addresses = new List<UserAddress>();
            Tokens = new List<UserToken>();
            AvatarName = "avatar.png";
            IsActive = true;
        }
        //Edit User
        public void Edit(string userName, string fullName, string email, string phoneNumber, Gender gender
            , IUserDomainService domainUserService)
        {
            Guard(phoneNumber, email, domainUserService);
            UserName = userName;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Gender = gender;
        }
        public void SetAvatar(string avatarName)
        {
            if (string.IsNullOrWhiteSpace(avatarName))
                AvatarName = "avatar.png";

            AvatarName = avatarName;
        }
        //Get User
        public static User RegisterUser(string password, string phoneNumber
            , IUserDomainService domainUserService)
        {
            return new User("", "", password, "ttew1dsdkt@gmail.com", phoneNumber, Gender.None, domainUserService);
        }
        //AddAsync Address user
        public void AddAddress(UserAddress Address)
        {
            Address.UserId = Id;
            Addresses.Add(Address);
        }
        //Edit Address User
        public void EditAddress(UserAddress address, long addressId)
        {
            var oldAddress = Addresses.FirstOrDefault(a => a.Id == addressId);
            if (oldAddress == null)
            {
                throw new NullOrEmptyDomainDataException("Address Not Found");
            }
            oldAddress.Edit(address.Shire, address.City, address.PostalCode, address.PostalAddress, address.Phone
                , address.Name, address.Family,
                address.NationalCode);
        }
        //Delete Address User
        public void DeleteAddress(long addressId)
        {
            var oldAddress = Addresses.FirstOrDefault(a => a.Id == addressId);
            if (oldAddress == null)
            {
                throw new NullOrEmptyDomainDataException("Address Not Found");
            }
            Addresses.Remove(oldAddress);
        }
        public void SetActiveAddress(long addressId)
        {
            var address = Addresses.FirstOrDefault(a => a.Id == addressId);
            if (address == null)
                throw new NullOrEmptyDomainDataException("ادرس مورد نظر یافت نشد");

            foreach (var userAddress in Addresses)
            {
                userAddress.SetDeActive();
            }
            address.SetActive();
        }
        //Charget Wallet User
        public void ChargeWallet(Wallet wallet)
        {
            wallet.UserId = Id;
            Wallets.Add(wallet);
        }
        //Set Role User
        public void SetRoles(List<UserRole> roles)
        {
            roles.ForEach(r => r.UserId = Id);
            Roles.Clear();
            Roles.AddRange(roles);
        }
        public void AddToken(string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
        {
            var activeTokenCount = Tokens.Count(c => c.RefreshTokenExpireDate > DateTime.Now);
            if (activeTokenCount == 3)
                throw new InvalidDomainDataException("امکان استفاده از 4 دستگاه همزمان وجود ندارد");

            var token = new UserToken(hashJwtToken, hashRefreshToken, tokenExpireDate, refreshTokenExpireDate, device);
            token.UserId = Id;
            Tokens.Add(token);
        }
        public string RemoveToken(long tokenId)
        {
            var token = Tokens.FirstOrDefault(f => f.Id == tokenId);
            if (token == null)
                throw new InvalidDomainDataException("شناسه توکن نامعتبر است");

            this.Tokens.Remove(token);
            return token.HashJwtToken;
        }
        public void ChangePassword(string newPassword)
        {
            NullOrEmptyDomainDataException.CheckString((newPassword, nameof(newPassword)));
            Password = newPassword;
        }
        public void SetActive(bool isActive)
        {
            IsActive = isActive;
        }

        //Validation User
        public void Guard(string phoneNumber, string email, IUserDomainService domainUserService)
        {
            NullOrEmptyDomainDataException.CheckString((phoneNumber, nameof(phoneNumber)));
            if (phoneNumber.Length != 11)
                throw new InvalidDomainDataException("شماره موبایل نامعتبر است");

            if (!string.IsNullOrWhiteSpace(email))
                if (email.IsValidEmail() == false)
                    throw new InvalidDomainDataException(" ایمیل  نامعتبر است");

            if (phoneNumber != PhoneNumber)
                if (domainUserService.IsPhoneNumberExist(phoneNumber))
                    throw new InvalidDomainDataException("شماره موبایل تکراری است");

            if (email != Email)
                if (domainUserService.IsEmailExist(email))
                    throw new InvalidDomainDataException("ایمیل تکراری است");
        }
    }
}
