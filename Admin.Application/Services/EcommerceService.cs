using Microsoft.Extensions.Configuration;
using Admin.Domain.Interface.Entities;
using Admin.Domain.Interface.Cache;
using Admin.Domain.Models.Response;
using Admin.Domain.Models.Response.Ecommerce;

namespace Admin.Application.Services
{
    public class EcommerceService
    {
        private readonly IWebSiteCarouselRepository _carouselRepository;
        private readonly IConfiguration _configuration;
        private readonly ICache _cache;

        public EcommerceService(
            IWebSiteCarouselRepository carouselRepository,
            IConfiguration configuration,
            ICache cache)
        {
            _carouselRepository = carouselRepository;
            _configuration = configuration;
            _cache = cache;
        }

        public async Task<BaseRs<List<CarouselRs>>> GetCarousels()
        {
            var _res = new BaseRs<List<CarouselRs>>();
            try
            {
                _res.Content = _cache.Get<List<CarouselRs>>("ecommerce-carousel");
                if (_res.Content == null)
                {
                    _res.Content = (await _carouselRepository.GetCarousels())
                        .ConvertAll(x => new CarouselRs()
                        {
                            image_mobile = $"{_configuration["s3:path"]}/carousel/{x.image_mobile}",
                            image = $"{_configuration["s3:path"]}/carousel/{x.image}",
                            new_tab = x.href_new_tab,
                            href = x.href,
                            title = x.name
                        });

                    // cache
                    _cache.Set(key: "ecommerce-carousel",
                               obj: _res.Content,
                               seconds: 600);
                }
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
    }
}