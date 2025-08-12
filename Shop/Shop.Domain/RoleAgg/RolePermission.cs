using Shop.Domain.RoleAgg.Enums;

namespace Shop.Domain.RoleAgg
{
    public class RolePermission
    {
        //Relation With Role 
        public long RoleId { get;internal set; }
        //Type Role
        public Permission Permission{ get;private set; }
    }
}
