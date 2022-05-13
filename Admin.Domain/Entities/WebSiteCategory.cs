using Admin.Domain.Entities.Base;

namespace Admin.Domain.Entities
{
    public class WebSiteCategory : BaseEntity
    {
        public Helpers.Enumerados.CategoryType category_type { get; set; }
        public string description_short { get; set; }
        public string description_long { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public bool active { get; set; }
        public long? parent_id { get; set; }
        public WebSiteCategory Parent { get; set; }
        public List<WebSiteCategory> SubCategories { get; set; } = new List<WebSiteCategory>();
    }
}
