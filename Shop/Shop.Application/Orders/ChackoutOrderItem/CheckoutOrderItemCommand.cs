using Common.Application;
using Shop.Domain.OrderAgg;

namespace Shop.Application.Orders.ChackoutOrderItem
{
    public class CheckoutOrderItemCommand : IBaseCommand
    {
        public CheckoutOrderItemCommand(long userId,string shire, string city, string postalCode, string postalAddress, string phoneNumber, string name, string family, string nationalCode)
        {
            UserId = userId;
            this.Shire = shire;
            this.City = city;
            this.PostalCode = postalCode;
            this.PostalAddress = postalAddress;
            this.PhoneNumber = phoneNumber;
            this.Name = name;
            this.Family = family;
            this.NationalCode = nationalCode;
        }
        public long UserId { get;set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string NationalCode { get; private set; }
    }
}
