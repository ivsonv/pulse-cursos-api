using Admin.Domain.Interface.Entities.Base;
using Admin.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Admin.Infra.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly AdminContext _context;
        public BaseRepository(AdminContext context)
        {
            _context = context;
        }

        public IQueryable<T> Query => _context.Set<T>().AsNoTracking();
        public IQueryable<T> QueryTrack => _context.Set<T>();

        public void Add(T entity) => _context.Add<T>(entity);
        public void AddRange(IList<T> entity) => _context.Set<T>().AddRange(entity);
        public void Update(T entity) => _context.Update<T>(entity);
        public void UpdateRange(IList<T> entity) => _context.UpdateRange(entity);
        public async Task<T> Find(long id) => await _context.Set<T>().FindAsync(id);
        public async Task<T> Find(Expression<Func<T, bool>> predicate) 
            => await _context.Set<T>().FirstOrDefaultAsync(predicate);

        public void Remove(T entity) => _context.Remove<T>(entity);
        public void RemoveRange(IList<T> entity) => _context.Set<T>().RemoveRange(entity);

        public async Task SaveChanges()
        {
            var entries = _context.ChangeTracker
                                  .Entries()
                                  .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
                                  .ToList();

            entries.ForEach(_entity =>
            {
                _entity.Property("updated_at").CurrentValue = System.DateTime.UtcNow;
                if (_entity.State == EntityState.Added)
                    _entity.Property("created_at").CurrentValue = _entity.Property("updated_at").CurrentValue;
                else
                    _entity.Property("created_at").IsModified = false;
            });
            await _context.SaveChangesAsync();
        }
        public async Task SaveHistory() 
            => await _context.SaveChangesAsync();

        public IQueryable<T> Get(Pagination pagination)
            => this.Query.Skip(pagination.size * pagination.page).Take(pagination.size);

        public IQueryable<T> Get(IQueryable<T> _query, Pagination pagination)
           => _query.AsNoTracking().Skip(pagination.size * pagination.page).Take(pagination.size);

        public IQueryable<T> Get(IQueryable<T> query, Expression<Func<T, object>> order, Pagination pagination)
        {
            if (pagination.asc)
                return query.OrderBy(order)
                                     .Skip(pagination.size * pagination.page)
                                     .Take(pagination.size);
            else
                return query.OrderByDescending(order)
                                     .Skip(pagination.size * pagination.page)
                                     .Take(pagination.size);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
            => this.Query.Where(predicate);

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate, Pagination pagination)
            => this.Query.Where(predicate).Skip(pagination.size * pagination.page).Take(pagination.size);

        public IQueryable<T> Get(Expression<Func<T, object>> order, Pagination pagination)
        {
            if (pagination.asc)
                return this.Query.OrderBy(order)
                                     .Skip(pagination.size * pagination.page)
                                     .Take(pagination.size);
            else
                return this.Query.OrderByDescending(order)
                                     .Skip(pagination.size * pagination.page)
                                     .Take(pagination.size);

        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, Pagination pagination)
        {
            if (pagination.asc)
                return this.Query.Where(predicate)
                                     .OrderBy(order)
                                     .Skip(pagination.size * pagination.page)
                                     .Take(pagination.size);
            else
                return this.Query.Where(predicate)
                                     .OrderByDescending(order)
                                     .Skip(pagination.size * pagination.page)
                                     .Take(pagination.size);
        }
    }
}