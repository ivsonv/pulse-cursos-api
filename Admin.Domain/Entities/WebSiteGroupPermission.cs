using Admin.Domain.Entities.Base;

namespace Admin.Domain.Entities
{
    public class WebSiteGroupPermission : BaseEntity
    {
        public string name { get; set; }
        public IEnumerable<WebSiteGroupPermissionAttached> PermissionsAttached { get; set; }
        public IEnumerable<WebSiteUserGroupPermission> Users { get; set; }
    }

    public class WebSiteGroupPermissionAttached : BaseEntity
    {
        public string name { get; set; }
        public long group_permission_id { get; set; }
        public WebSiteGroupPermission GroupPermission { get; set; }
    }
}
