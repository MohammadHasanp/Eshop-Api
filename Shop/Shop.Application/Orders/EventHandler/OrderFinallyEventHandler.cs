using MediatR;
using Shop.Domain.OrderAgg.Events;

namespace Shop.Application.Orders.EventHandler
{
    public class OrderFinallyEventHandler : INotificationHandler<OrderFinalliez>
    {

        public async Task Handle(OrderFinalliez notification, CancellationToken cancellationToken)
        {
             await Task.Delay(1000);
             Console.WriteLine("----------------------------");
        }
    }
}
