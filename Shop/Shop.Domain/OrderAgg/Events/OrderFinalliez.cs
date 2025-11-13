using Common.Domain;

namespace Shop.Domain.OrderAgg.Events
{
    public class OrderFinalliez:BaseDomainEvent
    {
        public long  OrderId { get;private set; }
        public OrderFinalliez(long orderId)
        {
            OrderId = orderId;
        }
    }
}
