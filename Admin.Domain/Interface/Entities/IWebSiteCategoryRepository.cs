using Admin.Domain.Interface.Entities.Base;
using Admin.Domain.Models;
using Admin.Domain.Models.Response.WebSite;

namespace Admin.Domain.Interface.Entities
{
    public interface IWebSiteCategoryRepository : ICrudRepository<Domain.Entities.WebSiteCategory>
    {
        Task<List<Domain.Entities.WebSiteCategory>> All();
        Task<List<CategoryRs>> Show(string search, Pagination pagination);
    }
}