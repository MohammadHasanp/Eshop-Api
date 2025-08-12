using Common.Domain;

namespace Shop.Domain.UserAgg
{
    public class UserRole:BaseEntity
    {
        //Relation With User
        public long UserId { get;internal set; }
        //Id Role
        public long RoleId { get; private set; }

        public UserRole(long roleId)
        {
            RoleId = roleId;
        }
    }
}
