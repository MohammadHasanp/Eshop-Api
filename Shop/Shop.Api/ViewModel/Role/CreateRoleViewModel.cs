using Shop.Domain.RoleAgg.Enums;

namespace Shop.Api.ViewModel.Role
{
    public class CreateRoleViewModel
    {
        public string Title { get; set; }
        public List<Permission>Permissions { get; set; }
    }
    public class EditRoleViewModel
    {
        public long roleId { get; set; }
        public string Title { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}
