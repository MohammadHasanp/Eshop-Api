using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.ProductAgg
{
    public class ProductSpecification:BaseEntity
    {
        //Relation With Product
        public long ProductId { get;internal set; }
        //Key
        public string Key { get;private set; }
        //Value
        public string Value { get;private set; }
        //Set ProductSpecification
        public ProductSpecification(string key, string value)
        {
            NullOrEmptyDomainDataException.CheckString((key,nameof(key)),(value,nameof(value)));
            Key = key;
            Value = value;
        }
    }
}
