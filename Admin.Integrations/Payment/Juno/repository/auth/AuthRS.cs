﻿namespace Admin.Integrations.Payment.Juno.repository.auth
{
    public class AuthRS
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string scope { get; set; }
        public string user_name { get; set; }
        public string jti { get; set; }
    }
}
