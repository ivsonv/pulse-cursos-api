using Admin.Domain.Entities;
using Admin.Domain.Helpers;
using Admin.Domain.Interface.Entities;
using Admin.Domain.Interface.Integrations.Storage;
using Admin.Domain.Models.Request;
using Admin.Domain.Models.Response;
using Admin.Domain.Models.Response.WebSite;
using Microsoft.Extensions.Configuration;

namespace Admin.Application.Services
{
    public class WebSiteCarouselService
    {
        private readonly IWebSiteCarouselRepository _carouselRepository;
        private readonly IConfiguration _configuration;
        private readonly IStorage _storage;

        public WebSiteCarouselService(
            IWebSiteCarouselRepository carouselRepository,
            IConfiguration configuration,
            IStorage storage)
        {
            _carouselRepository = carouselRepository;
            _configuration = configuration;
            _storage = storage;
        }

        public async Task<BaseRs<List<WebSiteCarousel>>> Show(BaseRq<WebSiteCarousel> _request)
        {
            var _res = new BaseRs<List<WebSiteCarousel>>();
            try
            {
                _res.Content = await _carouselRepository.Show(_request.Pagination);
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }

        public async Task<BaseRs<WebSiteCarousel>> Create(BaseRq<WebSiteCarousel> _req)
        {
            var _res = new BaseRs<WebSiteCarousel>();
            try
            {
                await _carouselRepository.Create(_req.Data);
                _res.Content = _req.Data;
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }

        public async Task<BaseRs<WebSiteCarousel>> Update(BaseRq<WebSiteCarousel> _req)
        {
            var _res = new BaseRs<WebSiteCarousel>();
            try
            {
                var _current = await _carouselRepository.FindById(_req.Data.id);
                if (_current != null)
                {
                    // remove imagem antiga
                    if (_current.image.IsNotEmpty() && _req.Data.image != _current.image)
                        await _storage.Remove($"carousel/{_current.image}");

                    // remove imagem antiga
                    if (_current.image_mobile.IsNotEmpty() && _req.Data.image_mobile != _current.image_mobile)
                        await _storage.Remove($"carousel/{_current.image_mobile}");

                    // mapper
                    _current.href_new_tab = _req.Data.href_new_tab;
                    _current.image_mobile = _req.Data.image_mobile;
                    _current.image = _req.Data.image;
                    _current.name = _req.Data.name;
                    _current.href = _req.Data.href;
                    _current.active = _req.Data.active;
                    _current.start = _req.Data.start;
                    _current.end = _req.Data.end;

                    // salvar
                    await _carouselRepository.Update(_current);
                    _res.Content = _req.Data;
                }
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }

        public async Task<BaseRs<CarouselRs>> FindById(long id)
        {
            var _res = new BaseRs<CarouselRs>() { Content = new CarouselRs() };
            try
            {
                _res.Content.data = await _carouselRepository.FindById(id);
                if (_res.Content.data != null)
                {
                    _res.Content.preview_image = _res.Content.data.image.IsNotEmpty()
                        ? string.Format("{0}/carousel/{1}", _configuration["s3:path"], _res.Content.data.image)
                        : null;

                    _res.Content.preview_mobile = _res.Content.data.image_mobile.IsNotEmpty()
                        ? string.Format("{0}/carousel/{1}", _configuration["s3:path"], _res.Content.data.image_mobile)
                        : null;
                }
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }

        public async Task<BaseRs<bool>> Delete(int id)
        {
            var _res = new BaseRs<bool>();
            try
            {
                var _entity = await _carouselRepository.FindById(id);

                // remove imagem antiga
                if (_entity.image.IsNotEmpty())
                    await _storage.Remove($"carousel/{_entity.image}");

                // remove imagem antiga
                if (_entity.image_mobile.IsNotEmpty())
                    await _storage.Remove($"carousel/{_entity.image_mobile}");

                await _carouselRepository.Delete(_entity);
                _res.Content = true;
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
    }
}