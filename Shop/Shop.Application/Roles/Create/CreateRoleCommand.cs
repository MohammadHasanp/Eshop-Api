using Common.Application;
using Shop.Domain.RoleAgg.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shop.Application.Roles.Create
{
    public class CreateRoleCommand : IBaseCommand
    {
        public string Title { get; private set; }
        public List<Permission> Permissions { get; private set; }

        public CreateRoleCommand(string title, List<Permission> permissions)
        {
            Title = title;
            Permissions = permissions;
        }
    }
}
