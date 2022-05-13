using static Admin.Domain.Helpers.Enumerados;

namespace Admin.Domain.Models.DTO.Auth
{
    public class AuthDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public AuthUserType UserType { get; set; }
        public IEnumerable<long> permissions { get; set; }
    }
}