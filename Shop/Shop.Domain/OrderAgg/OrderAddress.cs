using Common.Domain;

namespace Shop.Domain.OrderAgg
{
    public class OrderAddress:BaseEntity
    {
        //Set Order Address
        public  OrderAddress( string shire, string city, string postalCode, string postalAddress, string phoneNumber, string name, string family, string nationalCode)
        {
            this.Shire = shire;
            this.City = city;
            this.PostalCode = postalCode;
            this.PostalAddress = postalAddress;
            this.PhoneNumber = phoneNumber;
            this.Name = name;
            this.Family = family;
            this.NationalCode = nationalCode;
        }
        //Relation With Order
        public long OrderId { get;internal set; }
        //
        public string Shire { get; private set; }
        //
        public string City { get; private set; }
        //Code Post
        public string PostalCode { get; private set; }
        //Address Post
        public string PostalAddress { get; private set; }
        //
        public string PhoneNumber { get; private set; }
        //
        public string Name { get; private set; }
        //
        public string Family { get; private set; }
        //
        public string NationalCode { get; private set; }
        //Relation With Order
    }
}
   
