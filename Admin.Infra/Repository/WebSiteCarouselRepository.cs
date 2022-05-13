using Admin.Domain.Interface.Entities;
using Admin.Infra.Repository.Base;
using Admin.Domain.Entities;
using Admin.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Admin.Infra.Repository
{
    public class WebSiteCarouselRepository : IWebSiteCarouselRepository
    {
        private readonly BaseRepository<WebSiteCarousel> _repository;
        public WebSiteCarouselRepository(BaseRepository<WebSiteCarousel> repository)
        {
            _repository = repository;
        }

        public async Task<List<WebSiteCarousel>> Show(Pagination pagination)
        {
            return await _repository.Get(order: o => o.id, pagination)
                                    .Select(s => new WebSiteCarousel()
                                    {
                                        active = s.active,
                                        start = s.start,
                                        end = s.end,
                                        name = s.name,
                                        image = s.image,
                                        image_mobile = s.image_mobile,
                                        id = s.id,
                                    }).ToListAsync();
        }
        public async Task Create(WebSiteCarousel entity)
        {
            _repository.Add(entity);
            await _repository.SaveChanges();
        }
        public async Task Update(WebSiteCarousel entity)
        {
            _repository.Update(entity);
            await _repository.SaveChanges();
        }
        public async Task Delete(WebSiteCarousel entity)
        {
            _repository.Remove(entity);
            await _repository.SaveChanges();
        }
        public async Task<WebSiteCarousel> FindById(long id)
            => await _repository.Find(id);

        public async Task<List<WebSiteCarousel>> GetCarousels()
        {
            return await _repository.Query
                .Where(w => w.active)
                .Select(s => new WebSiteCarousel()
                {
                    href_new_tab = s.href_new_tab,
                    image_mobile = s.image_mobile,
                    image = s.image,
                    name = s.name,
                    href = s.href
                }).AsNoTracking().ToListAsync();
        }
    }
}