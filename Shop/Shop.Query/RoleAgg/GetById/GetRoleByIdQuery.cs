using Common.Query;
using Shop.Query.RoleAgg.DTOs;

namespace Shop.Query.RoleAgg.GetById
{
    public record GetRoleByIdQuery(long RoleId):IQuery<RoleDto>;
}
