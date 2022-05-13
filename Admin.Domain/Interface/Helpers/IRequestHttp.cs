using Admin.Domain.Models.DTO.Helpers;

namespace Admin.Domain.Interface.Helpers
{
    public interface IRequestHttp
    {
        Task<HttpRs> Post(HttpDto dto);
        Task<HttpRs> Get(HttpDto dto);
        Task<HttpRs> Get(string url);
    }
}