using Admin.Domain.Models;
namespace Admin.Domain.Interface.Entities.Base
{
    public interface ICrudRepository<T>
    {
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> FindById(long id);
        Task<List<T>> Show(Pagination pagination);
    }
}
