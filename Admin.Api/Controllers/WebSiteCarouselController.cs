using Admin.Domain.Models.DTO.Auth;
using Microsoft.AspNetCore.Mvc;
using Admin.Domain.Helpers;
using Admin.Application.Services;
using Admin.Domain.Models.Request;

namespace Admin.Api.Controllers
{
    [ApiExplorerSettings(GroupName = "website")]
    [Route("website/carousel")]
    public class WebSiteCarouselController
    {
        private readonly WebSiteCarouselService _carouselService;

        public WebSiteCarouselController(WebSiteCarouselService carouselService) 
        {
            _carouselService = carouselService;
        }

        //[HttpGet, AdminAuthorizeCustom(Permissions = Permission.WebSiteCarousel.View)]
        //public async Task<dynamic> Show([FromQuery] BaseRq<Domain.Entities.WebSiteCarousel> req)
        //    => await _carouselService.Show(req);

        //[HttpGet("{id:int}"), AdminAuthorizeCustom(Permissions = Permission.WebSiteCarousel.View)]
        //public async Task<dynamic> FindById([FromRoute] int id) 
        //    => await _carouselService.FindById(id);

        //[HttpPost, AdminAuthorizeCustom(Permissions = Permission.WebSiteCarousel.Create)]
        //public async Task<dynamic> Store([FromBody] BaseRq<Domain.Entities.WebSiteCarousel> _req) 
        //    => await _carouselService.Create(_req);

        //[HttpPut, AdminAuthorizeCustom(Permissions = Permission.WebSiteCarousel.Edit)]
        //public async Task<dynamic> Update([FromBody] BaseRq<Domain.Entities.WebSiteCarousel> _req) 
        //    => await _carouselService.Update(_req);

        //[HttpDelete("{id:int}"), AdminAuthorizeCustom(Permissions = Permission.WebSiteCarousel.Delete)]
        //public async Task<dynamic> Delete([FromRoute] int id)
        //    => await _carouselService.Delete(id);
    }
}