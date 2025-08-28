using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shop.Domain.RoleAgg;
using Shop.Infrastructure.Persistent.Ef.RoleAgg.Services;
using Shop.Query.RoleAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.RoleAgg.Mapper
{
    public static class RoleMapper
    {
        public static RoleDto Map(this Role role)
        {
            return new RoleDto()
            {
                CreationDate = role.CreationDate,
                Id = role.Id,
                Permissions = role.RolePermissions.Select(r=>r.Permission).ToList(),
                Title = role.Title
            };
        }

        public static List<RoleDto> MapList(this List<Role> role)
        {
            var roles = new List<RoleDto>();

            role.ForEach(r =>
            {
                roles.Add(new RoleDto()
                {
                    CreationDate = r.CreationDate,
                    Id = r.Id,
                    Permissions = r.RolePermissions.Select(r => r.Permission).ToList(),
                    Title = r.Title
                });
            });
            return roles;
        }
    }
}
