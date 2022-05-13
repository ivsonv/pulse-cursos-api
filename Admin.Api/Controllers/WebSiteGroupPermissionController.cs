using Admin.Domain.Models.DTO.Auth;
using Microsoft.AspNetCore.Mvc;
using Admin.Domain.Helpers;
using Admin.Application.Services;
using Admin.Domain.Models.Request;

namespace Admin.Api.Controllers
{
    [ApiExplorerSettings(GroupName = "website")]
    [Route("website/group-permission")]
    public class WebSiteGroupPermissionController
    {
        private readonly WebSiteGroupPermissionService _service;

        public WebSiteGroupPermissionController(WebSiteGroupPermissionService service)
        {
            _service = service;
        }

        //[HttpGet, AdminAuthorizeCustom(Permissions = Permission.WebSiteGroupPermission.View)]
        //public async Task<dynamic> Show()
        //    => await _service.Show(new BaseRq<string>());

        //[HttpGet("permissions"), AdminAuthorizeCustom(Permissions = Permission.WebSiteGroupPermission.View)]
        //public dynamic Permissions() => Permission.GetPermissions();

        //[HttpGet("{id:int}"), AdminAuthorizeCustom(Permissions = Permission.WebSiteGroupPermission.View)]
        //public async Task<dynamic> FindById([FromRoute] int id)
        //    => await _service.FindById(id);

        //[HttpPost, AdminAuthorizeCustom(Permissions = Permission.WebSiteGroupPermission.Create)]
        //public async Task<dynamic> Store([FromBody] BaseRq<Domain.Entities.WebSiteGroupPermission> _req)
        //    => await _service.Create(_req);

        //[HttpPut, AdminAuthorizeCustom(Permissions = Permission.WebSiteGroupPermission.Edit)]
        //public async Task<dynamic> Update([FromBody] BaseRq<Domain.Entities.WebSiteGroupPermission> _req)
        //    => await _service.Update(_req);

        //[HttpDelete("{id:int}"), AdminAuthorizeCustom(Permissions = Permission.WebSiteGroupPermission.Delete)]
        //public async Task<dynamic> Delete([FromRoute] int id)
        //    => await _service.Delete(id);
    }
}