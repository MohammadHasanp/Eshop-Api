using Common.Query;
using Shop.Query.UserAgg.DTOs;

namespace Shop.Query.UserAgg.Adrersses.Get
{
    public record GetUserAddressByIdQuery(long AddressId):IQuery<AddressDto>;
}
