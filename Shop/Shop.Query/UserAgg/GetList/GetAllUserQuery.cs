using Common.Query;
using Shop.Query.UserAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.UserAgg.GetList
{
    public record GetAllUserQuery():IQuery<List<UserDto>>;
}
