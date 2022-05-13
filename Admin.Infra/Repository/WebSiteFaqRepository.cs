using Admin.Domain.Interface.Entities;
using Admin.Infra.Repository.Base;
using Admin.Domain.Entities;
using Admin.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Admin.Infra.Repository
{
    public class WebSiteFaqRepository : IWebSiteFaqRepository
    {
        private readonly BaseRepository<WebSiteFaq> _repository;
        public WebSiteFaqRepository(BaseRepository<WebSiteFaq> repository)
        {
            _repository = repository;
        }

        public async Task<List<WebSiteFaq>> Show(Pagination pagination)
        {
            return await _repository.Get(order: o => o.id, pagination)
                                    .Select(s => new WebSiteFaq()
                                    {
                                        sub_title = s.sub_title,
                                        title = s.title,
                                        id = s.id,
                                    }).AsNoTracking().ToListAsync();
        }
        public async Task Create(WebSiteFaq entity)
        {
            _repository.Add(entity);
            await _repository.SaveChanges();
        }
        public async Task Update(WebSiteFaq entity)
        {
            _repository.Update(entity);
            await _repository.SaveChanges();
        }
        public async Task Delete(WebSiteFaq entity)
        {
            _repository.Remove(entity);
            await _repository.SaveChanges();
        }
        public async Task<WebSiteFaq> FindById(long id)
            => await _repository.Query
                                .Include(i => i.Questions)
                                .FirstOrDefaultAsync(f => f.id == id);
    }
}