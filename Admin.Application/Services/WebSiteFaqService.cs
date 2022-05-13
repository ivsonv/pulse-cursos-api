using Admin.Domain.Entities;
using Admin.Domain.Interface.Entities;
using Admin.Domain.Models.Request;
using Admin.Domain.Models.Response;

namespace Admin.Application.Services
{
    public class WebSiteFaqService
    {
        private readonly IWebSiteFaqRepository _faqRepository;
        public WebSiteFaqService(IWebSiteFaqRepository faqRepository)
        {
            _faqRepository = faqRepository;
        }
        public async Task<BaseRs<List<WebSiteFaq>>> Show(BaseRq<string> _request)
        {
            var _res = new BaseRs<List<WebSiteFaq>>();
            try
            {
                _res.Content = await _faqRepository.Show(_request.Pagination);
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
        public async Task<BaseRs<WebSiteFaq>> Create(BaseRq<WebSiteFaq> _req)
        {
            var _res = new BaseRs<WebSiteFaq>();
            try
            {
                await _faqRepository.Create(_req.Data);
                _res.Content = _req.Data;
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
        public async Task<BaseRs<WebSiteFaq>> Update(BaseRq<WebSiteFaq> _req)
        {
            var _res = new BaseRs<WebSiteFaq>();
            try
            {
                await _faqRepository.Update(_req.Data);
                _res.Content = _req.Data;
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
        public async Task<BaseRs<WebSiteFaq>> FindById(long id)
        {
            var _res = new BaseRs<WebSiteFaq>();
            try
            {
                _res.Content = await _faqRepository.FindById(id);
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
        public async Task<BaseRs<bool>> Delete(int id)
        {
            var _res = new BaseRs<bool>();
            try
            {
                await _faqRepository.Delete(await _faqRepository.FindById(id));
                _res.Content = true;
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
    }
}