using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using System.Drawing;
using System.Reflection.Metadata;
using System.Xml.Linq;
using static Common.Domain.Exceptions.BaseDomainExceotion;

namespace Shop.Domain.UserAgg
{
    public class UserAddress : BaseEntity
    {
        public UserAddress() { }
        //Relation With User
        public long UserId { get; internal set; }
        //
        public string Shire { get; private set; }
        //City User
        public string City { get; private set; }
        //Code Post
        public string PostalCode { get; private set; }
        //Address Post
        public string PostalAddress { get; private set; }
        //Phone User
        public PhoneNumber Phone { get; private set; }
        //Name User
        public string Name { get; private set; }
        //Family User
        public string Family { get; private set; }
        //Nationalcode User
        public string NationalCode { get; private set; }
        //User Address Activation
        public bool IsActive { get; private set; }
        //Set Address User
        public UserAddress(string shire, string city, string postalCode, string postalAddress, PhoneNumber phone, string name, string family, string nationalCode)
        {
            Guard(shire,city,postalCode,phone, postalAddress,name,family,nationalCode);
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            Phone = phone;
            Name = name;
            Family = family;
            NationalCode = nationalCode;
            IsActive = false;
        }
        //Set Active Address User
        public void SetActive()
        {
            IsActive = true;
        }
        //Edit Addres User
        public void Edit(string shire, string city, string postalCode, string postalAddress, PhoneNumber phone, string name, string family, string nationalCode)
        {
            Guard(shire,city,postalCode,phone,postalAddress,name,family,nationalCode);
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            Phone = phone;
            Name = name;
            Family = family;
            NationalCode = nationalCode;
        }
        //Validation Address User
        public void Guard(string shire, string city, string postalCode,PhoneNumber phone, string postalAddress, string name, string family, string nationalCode)
        {
            NullOrEmptyDomainDataException.CheckString((shire, nameof(shire)), (city, nameof(city)), (postalCode, nameof(postalCode)), (postalAddress, nameof(postalAddress)),(name,nameof(name)),(family,nameof(family)),(nationalCode,nameof(nationalCode)));
            if (phone == null)
                throw new InvalidDomainDataException("شماره تلفن نامعتبر است");
            if (!IranianNationalIdChecker.IsValid(nationalCode))
                throw new InvalidDomainDataException("کدملی نامعتبر است");
        }
    }
}
