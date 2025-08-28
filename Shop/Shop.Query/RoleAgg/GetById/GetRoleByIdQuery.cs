using Common.Query;
using Shop.Query.RoleAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.RoleAgg.GetById
{
    public record GetRoleByIdQuery(long RoleId):IQuery<RoleDto>;
}
