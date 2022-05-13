namespace Admin.Domain.Models.DTO.Auth
{
    public class AuthRs
    {
        public string AccessToken { get; set; }
        public AuthData Data { get; set; }
    }

    public class AuthData
    {
        public string FullName { get; set; }
        public IEnumerable<string> Rules { get; set; }
        public string avatar { get; set; }
        public long Id { get; set; }
    }
}