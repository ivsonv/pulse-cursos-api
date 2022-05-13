using System.Text;

namespace Admin.Domain.Models.DTO.Helpers
{
    public class HttpDto
    {
        public string Url { get; set; }
        public object Payload { get; set; }
        public FormUrlEncodedContent PayloadFormUrlEncode { get; set; }
        public Encoding Encoding { get; set; } = Encoding.Default;
        public List<HeadersDto> Headers { get; set; }
    }

    public class HeadersDto
    {
        public string name { get; set; }
        public string value { get; set; }
        public string scheme { get; set; }
    }
}