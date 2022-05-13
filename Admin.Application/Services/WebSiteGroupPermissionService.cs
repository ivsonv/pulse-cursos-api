using Admin.Domain.Interface.Entities;
using Admin.Domain.Models.Request;
using Admin.Domain.Models.Response;

namespace Admin.Application.Services
{
    public class WebSiteGroupPermissionService
    {
        private readonly IWebSiteGroupPermissionRepository _repository;
        public WebSiteGroupPermissionService(IWebSiteGroupPermissionRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseRs<List<Domain.Entities.WebSiteGroupPermission>>> Show(BaseRq<string> _request)
        {
            var _res = new BaseRs<List<Domain.Entities.WebSiteGroupPermission>>();
            try
            {
                _res.Content = await _repository.Show(_request.Pagination);
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
        public async Task<BaseRs<Domain.Entities.WebSiteGroupPermission>> FindById(long id)
        {
            var _res = new BaseRs<Domain.Entities.WebSiteGroupPermission>();
            try
            {
                _res.Content = await _repository.FindById(id);
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
        public async Task<BaseRs<Domain.Entities.WebSiteGroupPermission>> Create(BaseRq<Domain.Entities.WebSiteGroupPermission> _req)
        {
            var _res = new BaseRs<Domain.Entities.WebSiteGroupPermission>();
            try
            {
                await _repository.Create(_req.Data);
                _res.Content = _req.Data;
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
        public async Task<BaseRs<Domain.Entities.WebSiteGroupPermission>> Update(BaseRq<Domain.Entities.WebSiteGroupPermission> _req)
        {
            var _res = new BaseRs<Domain.Entities.WebSiteGroupPermission>();
            try
            {
                await _repository.Update(_req.Data);
                _res.Content = _req.Data;
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
        public async Task<BaseRs<bool>> Delete(int id)
        {
            var _res = new BaseRs<bool>();
            try
            {
                await _repository.Delete(await _repository.FindById(id));
                _res.Content = true;
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
    }
}