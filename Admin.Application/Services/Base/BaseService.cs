using Admin.Domain.Interface.Entities.Base;
using Admin.Domain.Interface.Services;
using Admin.Domain.Models.Request;
using Admin.Domain.Models.Response;
using Admin.Infra.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Admin.Application.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly BaseRepository<T> _repository;

        public BaseService(BaseRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<BaseRs> Index(BaseRq<T> Req)
        {
            var _res = new BaseRs();
            try
            {
                _res.content = await _repository.Get(Req.Pagination).ToListAsync();
            }
            catch (Exception ex) { _res.SetError(ex); }

            return _res;
        }

        public async Task<BaseRs> Store(BaseRq<T> Req)
        {
            var _res = new BaseRs();
            try
            {
                _repository.Add(Req.Data);
                await _repository.SaveChanges();

                _res.content = Req.Data;
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }

        public async Task<BaseRs> Update(BaseRq<T> Req)
        {
            var _res = new BaseRs();
            try
            {
                _repository.Update(Req.Data);
                await _repository.SaveChanges();

                _res.content = Req.Data;
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }

        public async Task<BaseRs> Delete(int id)
        {
            var _res = new BaseRs();
            try
            {
                var entity = await _repository.Find(id);
                _repository.Remove(entity);

                _res.content = true;
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }

        public async Task<BaseRs> FindById(int id)
        {
            var _res = new BaseRs();
            try
            {
                _res.content = await _repository.Find(id);
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
    }
}