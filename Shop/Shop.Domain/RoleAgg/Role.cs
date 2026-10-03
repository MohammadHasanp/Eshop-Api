using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Shop.Domain.RoleAgg
{
    public class Role : AggregateRoot
    {
        //
        public string Title { get; private set; }
        //Relation With RolePermission
        public List<RolePermission> RolePermissions { get; private set; }
        //Set Role
        public Role(string title, List<RolePermission> rolePermissions)
        {
            NullOrEmptyDomainDataException.CheckString((title, nameof(title)));
            Title = title;
            RolePermissions = rolePermissions;
        }
        //Edit Title
        public void Edit(string title)
        {
            NullOrEmptyDomainDataException.CheckString((title, nameof(title)));
            Title = title;
        }
        //For EfCore
        private Role() { }
        //Set Permission
        public void SetPermission(List<RolePermission> permissions)
        {
            RolePermissions = permissions;
        }
    }
}
