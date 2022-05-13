using Admin.Domain.Entities;
using Admin.Domain.Interface.Entities.Base;

namespace Admin.Domain.Interface.Entities
{
    public interface IWebSiteGroupPermissionRepository : ICrudRepository<WebSiteGroupPermission>
    {
        List<WebSiteGroupPermission> All();
    }
}