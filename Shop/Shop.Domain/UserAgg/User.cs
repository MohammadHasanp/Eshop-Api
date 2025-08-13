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
        //UserNAme User
        public string UserName { get; private set; }
        //FullName User
        public string FullName { get; private set; }
        //Password User
        public string Password { get; set; }
        //Email User
        public string Email { get; private set; }
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

        //Set User
        public User(string userName, string fullName, string password, string email, string phoneNumber, Gender gender, IDomainUserService domainUserService)
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
        }
        //Edit User
        public void Edit(string userName, string fullName, string email, string phoneNumber, Gender gender, IDomainUserService domainUserService)
        {
            Guard(phoneNumber, email, domainUserService);
            UserName = userName;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Gender = gender;
        }
        //Get User
        public static User RegisterUser(string password,string email, string phoneNumber, IDomainUserService domainUserService)
        {
            return new User("","",password,email,phoneNumber,Gender.None,domainUserService);
        }
        //Add Address user
        public void AddAddress( UserAddress Address)
        {
            Address.UserId = Id;
            Addresses.Add(Address);
        }
        //Edit Address User
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
        //Charget Wallet User
        public void ChargeWallet(Wallet wallet)
        {
            wallet.UserId = Id;
            Wallets.Add(wallet);
        }
        //Set Role User
        public void SetRoles(List<UserRole> roles)
        {
            roles.ForEach(r=>r.UserId = Id);
            Roles.Clear();
             Roles.AddRange(roles);
        }
        //Validation User
        public void Guard(string phoneNumber, string email, IDomainUserService domainUserService)
        {
            NullOrEmptyDomainDataException.CheckString((phoneNumber, nameof(phoneNumber)), (email, nameof(email)));
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
