using Admin.Domain.Models;
using System.Linq.Expressions;

namespace Admin.Domain.Interface.Entities.Base
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task<T> Find(long id);
        Task<T> Find(Expression<Func<T, bool>> predicate);
        void RemoveRange(IList<T> entity);
        void AddRange(IList<T> entity);
        Task SaveChanges();

        IQueryable<T> Get(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, Pagination pagination);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate, Pagination pagination);
        IQueryable<T> Get(Expression<Func<T, object>> order, Pagination pagination);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> Get(Pagination pagination);
    }
}