using Admin.Domain.Models.DTO.Auth;
using Microsoft.AspNetCore.Mvc;
using Admin.Domain.Helpers;
using Admin.Application.Services;
using Admin.Domain.Models.Request;
using Admin.Domain.Models.Response;

namespace Admin.Api.Controllers
{
    [ApiExplorerSettings(GroupName = "website")]
    [Route("website/user")]
    public class WebSiteUserController
    {
        private readonly WebSiteUserService _userService;

        public WebSiteUserController(WebSiteUserService userService) 
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<BaseRs<AuthRs>> Login([FromBody] Domain.Models.Request.User.AuthRq _req)
            => await _userService.Login(_req);

        //[HttpGet, AdminAuthorizeCustom(Permissions = Permission.WebSiteUser.View)]
        //public async Task<dynamic> Show([FromQuery] BaseRq<string> _req)
        //    => await _userService.Show(_req);

        //[HttpGet("{id:int}"), AdminAuthorizeCustom(Permissions = Permission.WebSiteUser.View)]
        //public async Task<dynamic> FindById([FromRoute] int id)
        //    => await _userService.FindById(id);

        //[HttpPost, AdminAuthorizeCustom(Permissions = Permission.WebSiteUser.Create)]
        //public async Task<dynamic> Store([FromBody] BaseRq<Domain.Entities.WebSiteUser> _req)
        //     => await _userService.Create(_req);

        //[HttpPut, AdminAuthorizeCustom(Permissions = Permission.WebSiteUser.Edit)]
        //public async Task<dynamic> Update([FromBody] BaseRq<Domain.Entities.WebSiteUser> _req)
        //    => await _userService.Update(_req);

        //[HttpDelete("{id:int}"), AdminAuthorizeCustom(Permissions = Permission.WebSiteUser.Delete)]
        //public async Task<dynamic> Delete([FromRoute] int id)
        //    => await _userService.Delete(id);
    }
}