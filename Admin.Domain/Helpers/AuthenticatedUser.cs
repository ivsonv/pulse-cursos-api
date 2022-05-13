using Admin.Domain.Models.DTO.Auth;
using Microsoft.AspNetCore.Http;

namespace Admin.Domain.Helpers
{
    public class AuthenticatedUser
    {
        private readonly IHttpContextAccessor _accessor;
        public AuthenticatedUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public AuthDto user
        {
            get
            {
                return _accessor.HttpContext.User.Claims
                                 .FirstOrDefault(f => f.Type == System.Security.Claims.ClaimTypes.UserData)?
                                 .Value.Deserialize<AuthDto>();
            }
        }
    }
}
