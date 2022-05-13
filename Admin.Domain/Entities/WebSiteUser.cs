using Admin.Domain.Entities.Base;

namespace Admin.Domain.Entities
{
    public class WebSiteUser : BaseEntity
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool active { get; set; }
        public IEnumerable<WebSiteUserGroupPermission> GroupPermissions { get; set; }
    }
    public class WebSiteUserGroupPermission : BaseEntity
    {
        public long user_id { get; set; }
        public long group_permission_id { get; set; }

        public WebSiteUser User { get; set; }
        public WebSiteGroupPermission GroupPermission { get; set; }
    }
}
