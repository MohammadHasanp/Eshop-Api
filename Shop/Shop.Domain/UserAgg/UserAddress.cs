using Common.Domain;
using Common.Domain.Exceptions;
using System.Drawing;
using System.Reflection.Metadata;
using System.Xml.Linq;
using static Common.Domain.Exceptions.BaseDomainExceotion;

namespace Shop.Domain.UserAgg
{
    public class UserAddress : BaseEntity
    {
        public long UserId { get; internal set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string NationalCode { get; private set; }
        public bool IsActive { get; private set; }

        public UserAddress(string shire, string city, string postalCode, string postalAddress, string phoneNumber, string name, string family, string nationalCode)
        {
            Guard(shire,city,postalCode,postalAddress,phoneNumber,name,family,nationalCode);
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            Name = name;
            Family = family;
            NationalCode = nationalCode;
            IsActive = false;
        }
        public void SetActive()
        {
            IsActive = true;
        }

        public void Edit(string shire, string city, string postalCode, string postalAddress, string phoneNumber, string name, string family, string nationalCode)
        {
            Guard(shire,city,postalCode,postalAddress,phoneNumber,name,family,nationalCode);
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            Name = name;
            Family = family;
            NationalCode = nationalCode;
        }
        public void Guard(string shire, string city, string postalCode, string postalAddress, string phoneNumber, string name, string family, string nationalCode)
        {
            NullOrEmptyDomainDataException.ValidatePairs((shire, nameof(shire)), (city, nameof(city)), (postalCode, nameof(postalCode)), (postalAddress, nameof(postalAddress)),(name,nameof(name)),(family,nameof(family)),(nationalCode,nameof(nationalCode)));
            
            if (!IranianNationalIdChecker.IsValid(nationalCode))
                throw new InvalidDomainDataException("NationalCode InValid");
        }
    }
}
