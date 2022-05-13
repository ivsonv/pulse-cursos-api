using Admin.Domain.Models.Request;
using Admin.Domain.Models.Response;

namespace Admin.Domain.Interface.Services
{
    public interface IBaseService<T>
    {
        Task<BaseRs> Index(BaseRq<T> Req);
        Task<BaseRs> Store(BaseRq<T> Req);
        Task<BaseRs> Update(BaseRq<T> Req);
        Task<BaseRs> FindById(int id);
        Task<BaseRs> Delete(int id);
    }
}