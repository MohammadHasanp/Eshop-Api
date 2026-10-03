
using Common.Domain;
using Common.Domain.Exceptions;
using System.Threading.Channels;

namespace Shop.Domain.SiteEntities
{
    public class ShippingMothod:BaseEntity
    {
        public ShippingMothod(string title,int cost)
        {
            NullOrEmptyDomainDataException.CheckString((title,nameof(title)));
            Title = title;
            Cost = cost;
        }
        public void Edit(string title,int cost)
        {
            NullOrEmptyDomainDataException.CheckString((title,nameof(title)));
            Title = title;
            cost = Cost;
        }

        public string Title { get;private set; }
        public int Cost { get;private set; }
        
    }
}
