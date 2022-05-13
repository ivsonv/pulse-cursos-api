using Admin.Domain.Interface.Entities;
using Admin.Infra.Repository.Base;
using Admin.Domain.Entities;
using Admin.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Admin.Domain.Helpers;
using Admin.Domain.Models.Response.WebSite;

namespace Admin.Infra.Repository
{
    public class WebSiteCategoryRepository : IWebSiteCategoryRepository
    {
        private readonly BaseRepository<WebSiteCategory> _repository;
        public WebSiteCategoryRepository(BaseRepository<WebSiteCategory> repository)
        {
            _repository = repository;
        }

        public async Task<List<CategoryRs>> Show(string search, Pagination pagination)
        {
            var _query = _repository.Query;

            // sem filtro por nome 
            if (search.IsEmpty()) _query = _query.Where(w => w.parent_id == null);
            else
            {
                _query = _query.Where(w =>  w.name.ToLower().Trim().Contains(search.ToLower().Trim()));
            }

            // retorno
            return await _repository.Get(query: _query, order: o => o.id, pagination)
                                    .Select(s => new CategoryRs()
                                    {
                                        category_type = s.category_type,
                                        parent_id = s.parent_id,
                                        active = s.active,
                                        name = s.name,
                                        id = s.id,
                                    }).ToListAsync();
        }

        public async Task<List<WebSiteCategory>> Show(Pagination pagination)
        {
            return await _repository.Get(order: o => o.id, pagination)
                                    .Select(s => new WebSiteCategory()
                                    {
                                        category_type = s.category_type,
                                        parent_id = s.parent_id,
                                        name = s.name,
                                        id = s.id,
                                    }).ToListAsync();
        }
        public async Task Create(WebSiteCategory entity)
        {
            _repository.Add(entity);
            await _repository.SaveChanges();
        }
        public async Task Update(WebSiteCategory entity)
        {
            _repository.Update(entity);
            await _repository.SaveChanges();
        }
        public async Task Delete(WebSiteCategory entity)
        {
            _repository.Remove(entity);
            await _repository.SaveChanges();
        }
        public async Task<WebSiteCategory> FindById(long id)
            => await _repository.Query
                                .Include(i => i.Parent)
                                .Include(i => i.SubCategories)
                                .FirstOrDefaultAsync(f => f.id == id);

        public async Task<List<WebSiteCategory>> All()
        {
            return await _repository.Query.Select(s => new WebSiteCategory()
            {
                category_type = s.category_type,
                parent_id = s.parent_id,
                name = s.name,
                id = s.id,
            }).ToListAsync();
        }
    }
}