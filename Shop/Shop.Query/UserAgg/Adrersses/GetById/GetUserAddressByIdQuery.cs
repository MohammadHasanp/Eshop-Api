using Common.Query;
using Shop.Query.UserAgg.DTOs;

namespace Shop.Query.UserAgg.Adrersses.GetById
{
    public record GetUserAddressByIdQuery(long AddressId):IQuery<AddressDto>;
}
