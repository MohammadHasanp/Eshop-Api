using Common.Domain;
using Common.Domain.Exceptions;
using Microsoft.IdentityModel.Tokens;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Common.Domain.Exceptions.BaseDomainExceotion;

namespace Shop.Domain.UserAgg
{
    public class User : AggregateRoot
    {
        public string UserName { get; private set; }
        public string FullName { get; private set; }
        public string Password { get; set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public Gender Gender { get; private set; }
        public List<UserRole> Roles { get; private set; }
        public List<Wallet> Wallets { get; private set; }
        public List<UserAddress> Addresses { get; private set; }

        public User(string userName, string fullName, string password, string email, string phoneNumber, Gender gender, IDomainUserService domainUserService)
        {
            Guard(phoneNumber, email, domainUserService);
            UserName = userName;
            FullName = fullName;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
            Gender = gender;
            //Roles = new List<UserRole>();
            //Wallets = new List<Wallet>();
            //Addresses = new List<UserAddress>();
        }

        public void Edit(string userName, string fullName, string email, string phoneNumber, Gender gender, IDomainUserService domainUserService)
        {
            Guard(phoneNumber, email, domainUserService);
            UserName = userName;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Gender = gender;
        }
        public static User RegisterUser(string password,string email, string phoneNumber, IDomainUserService domainUserService)
        {
            return new User("","",password,email,phoneNumber,Gender.None,domainUserService);
        }
        public void AddAddress( UserAddress Address)
        {
            Address.UserId = Id;
            Addresses.Add(Address);
        }
        public void EditAddress(UserAddress address)
        {
            var oldAddress = Addresses.FirstOrDefault(a => a.UserId == address.Id);
            if (oldAddress == null)
            {
                throw new NullOrEmptyDomainDataException("Address Not Found");
            }
            Addresses.Remove(oldAddress);
            Addresses.Add(address);
        }
        public void DeleteAddress(long addressId)
        {
            var oldAddress = Addresses.FirstOrDefault(a => a.Id == addressId);
            if (oldAddress == null)
            {
                throw new NullOrEmptyDomainDataException("Address Not Found");
            }
            Addresses.Remove(oldAddress);
        }

        public void ChargeWallet(Wallet wallet)
        {
            wallet.UserId = Id;
            Wallets.Add(wallet);
        }

        public void SetRoles(List<UserRole> roles)
        {
            roles.ForEach(r=>r.UserId = Id);
            Roles.Clear();
             Roles.AddRange(roles);
        }
        public void Guard(string phoneNumber, string email, IDomainUserService domainUserService)
        {
            NullOrEmptyDomainDataException.ValidatePairs((phoneNumber, nameof(phoneNumber)), (email, nameof(email)));
            if (phoneNumber.Length != 11)
            {
                throw new InvalidDomainDataException("Phone Is Invalid");
            }
            if (!email.IsValidEmail())
            {
                throw new InvalidDomainDataException("Email Is Invalid");
            }
            if (phoneNumber != PhoneNumber)
                if (domainUserService.IsPhoneNumberExist(phoneNumber))
                    throw new InvalidDomainDataException("Phone Is Duplicate");
            if (email != Email)
                if (domainUserService.IsEmailExist(email))
                    throw new InvalidDomainDataException("Email Is Duplicate");
        }
    }
}
