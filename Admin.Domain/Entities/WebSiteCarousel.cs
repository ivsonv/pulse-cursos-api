using Admin.Domain.Entities.Base;

namespace Admin.Domain.Entities
{
    public class WebSiteCarousel : BaseEntity
    {
        public string name { get; set; }
        public string image { get; set; }
        public string image_mobile { get; set; }
        public string href { get; set; }
        public bool href_new_tab { get; set; }
        public bool active { get; set; }
        public DateTime? start { get; set; }
        public DateTime? end { get; set; }
    }
}