using Common.Application;

namespace Shop.Application.Sellers.Create
{
    public record CreateSellerCommand(long UserId, string ShopName, string NationalCode) : IBaseCommand;
}
