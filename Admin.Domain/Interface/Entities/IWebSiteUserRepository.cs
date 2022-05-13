using Admin.Domain.Interface.Entities.Base;
using Admin.Domain.Models;

namespace Admin.Domain.Interface.Entities
{
    public interface IWebSiteUserRepository : ICrudRepository<Domain.Entities.WebSiteUser>
    {
        Task<List<Domain.Entities.WebSiteUser>> Show(Pagination pagination, string search);
        Task<Domain.Entities.WebSiteUser> FindByEmail(string email);
        Task<Domain.Entities.WebSiteUser> FindByLogin(string email);
    }
}