
using Common.Domain.ValueObjects;

namespace Shop.Query.UserAgg.DTOs
{
    public class AddressDto
    {
        public long UserId { get; set; }
        public string Shire { get;  set; }
        public string City { get;  set; }
        public string PostalCode { get; set; }
        public string PostalAddress { get; set; }
        public PhoneNumber Phone { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalCode { get;set; }
        public bool IsActive { get; set; }
    }
}
