using Admin.Domain.Entities;
using Admin.Domain.Interface.Entities;
using Admin.Domain.Models.Request;
using Admin.Domain.Models.Response;

namespace Admin.Application.Services
{
    public class WebSiteFaqQuestionService
    {
        private readonly IWebSiteFaqQuestionRepository _faqQuestionRepository;
        public WebSiteFaqQuestionService(IWebSiteFaqQuestionRepository qRepository)
        {
            _faqQuestionRepository = qRepository;
        }

        public async Task<BaseRs<List<WebSiteFaqQuestion>>> Show(BaseRq<string> _request)
        {
            var _res = new BaseRs<List<WebSiteFaqQuestion>>();
            try
            {
                _res.Content = await _faqQuestionRepository.Show(_request.Pagination);
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
        public async Task<BaseRs<WebSiteFaqQuestion>> Create(BaseRq<WebSiteFaqQuestion> _req)
        {
            var _res = new BaseRs<WebSiteFaqQuestion>();
            try
            {
                await _faqQuestionRepository.Create(_req.Data);
                _res.Content = _req.Data;
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
        public async Task<BaseRs<WebSiteFaqQuestion>> Update(BaseRq<WebSiteFaqQuestion> _req)
        {
            var _res = new BaseRs<WebSiteFaqQuestion>();
            try
            {
                await _faqQuestionRepository.Update(_req.Data);
                _res.Content = _req.Data;
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
        public async Task<BaseRs<WebSiteFaqQuestion>> FindById(long id)
        {
            var _res = new BaseRs<WebSiteFaqQuestion>();
            try
            {
                _res.Content = await _faqQuestionRepository.FindById(id);
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
        public async Task<BaseRs<bool>> Delete(int id)
        {
            var _res = new BaseRs<bool>();
            try
            {
                await _faqQuestionRepository.Delete(await _faqQuestionRepository.FindById(id));
                _res.Content = true;
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
    }
}