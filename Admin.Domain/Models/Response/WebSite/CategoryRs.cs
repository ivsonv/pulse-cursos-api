using Admin.Domain.Helpers;

namespace Admin.Domain.Models.Response.WebSite
{
    public class CategoryRs : Entities.WebSiteCategory
    {
        public string ds_category_type
        {
            get
            {
                return base.category_type.GetDescription();
            }
        }

    }
}