using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Admin.Domain.Models.DTO.Auth;
using Admin.Domain.Interface.Entities;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Admin.Domain.Helpers
{
    public class AdminAuthorizeCustom : AuthorizeAttribute, IAuthorizationFilter
    {
        public string Permissions { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // caso não tenha permissão, gerar uma dinamica
            if (this.Permissions.IsEmpty())
            {
                var _descriptor = (ControllerActionDescriptor)context.ActionDescriptor;
                this.Permissions = $"{_descriptor.ActionName}_{_descriptor.ControllerName}".ToLower().Trim();
            }

            var user = context.HttpContext.User.Claims
                 .FirstOrDefault(f => f.Type == ClaimTypes.UserData)?
                 .Value.Deserialize<AuthDto>();

            if (user != null)
            {
                switch (user.UserType)
                {
                    case Enumerados.AuthUserType.partners:
                        if (Permission.Account.Partners == Permissions)
                            return; // permitido.
                        break;

                    case Enumerados.AuthUserType.admin:
                        // não requisitar no banco
                        var _groupPermission = (IWebSiteGroupPermissionRepository)context.HttpContext.RequestServices.GetService(typeof(IWebSiteGroupPermissionRepository));

                        // permissions
                        var _permissions = _groupPermission.All()
                                                 .Where(w => user.permissions.Any(g => g == w.id))
                                                 .SelectMany(s => s.PermissionsAttached)
                                                 .Select(s => s.name)
                                                 .Distinct().ToList();

                        // verificar se tem a permissão.
                        if (_permissions.Any(a => Permissions.Split(',').Any(aa => aa == a)))
                            return; // continuar, pois tem permissão.
                        break;
                }
            }

            context.Result = new UnauthorizedResult();
            return;
        }
    }

}
