using Common.Domain;

namespace Shop.Domain.UserAgg
{
    public class UserRole:BaseEntity
    {
        private UserRole() {}
        //Relation With User
        public long UserId { get;internal set; }
        //Id Role
        public long RoleId { get; private set; }
        //Set UserRole
        public UserRole(long roleId)
        {
            RoleId = roleId;
        }
    }
}
