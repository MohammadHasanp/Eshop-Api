using Common.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Shop.Query.UserAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.UserAgg.GetById
{
    public record GetUserByIdQuery(long UserId):IQuery<UserDto>;
}
