using Admin.Domain.Interface.Entities;
using Admin.Infra.Repository.Base;
using Admin.Domain.Entities;
using Admin.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Admin.Infra.Repository
{
    public class WebSiteFaqQuestionRepository : IWebSiteFaqQuestionRepository
    {
        private readonly BaseRepository<WebSiteFaqQuestion> _repository;
        public WebSiteFaqQuestionRepository(BaseRepository<WebSiteFaqQuestion> repository)
        {
            _repository = repository;
        }

        public async Task<List<WebSiteFaqQuestion>> Show(Pagination pagination)
        {
            return await _repository.Get(order: o => o.id, pagination)
                                    .Select(s => new WebSiteFaqQuestion()
                                    {
                                        question = s.question,
                                        ans = s.ans,
                                        id = s.id,
                                    }).AsNoTracking().ToListAsync();
        }
        public async Task Create(WebSiteFaqQuestion entity)
        {
            _repository.Add(entity);
            await _repository.SaveChanges();
        }
        public async Task Update(WebSiteFaqQuestion entity)
        {
            _repository.Update(entity);
            await _repository.SaveChanges();
        }
        public async Task Delete(WebSiteFaqQuestion entity)
        {
            _repository.Remove(entity);
            await _repository.SaveChanges();
        }
        public async Task<WebSiteFaqQuestion> FindById(long id)
            => await _repository.Query
                                .Include(i => i.Faq)
                                .FirstOrDefaultAsync(f => f.id == id);
    }
}