using Common.Application;

namespace Shop.Application.ShippingMethod.Create
{
    public record CreateShippingMethodCommand(string Title,int Cost):IBaseCommand;
}
