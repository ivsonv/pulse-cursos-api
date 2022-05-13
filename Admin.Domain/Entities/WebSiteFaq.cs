using Admin.Domain.Entities.Base;

namespace Admin.Domain.Entities
{
    public class WebSiteFaq : BaseEntity
    {
        public string title { get; set; }
        public string sub_title { get; set; }
        public IEnumerable<WebSiteFaqQuestion> Questions { get; set; }
    }
    public class WebSiteFaqQuestion : BaseEntity
    {
        public string question { get; set; }
        public string ans { get; set; }
        public long faq_id { get; set; }
        public WebSiteFaq Faq { get; set; }
    }
}