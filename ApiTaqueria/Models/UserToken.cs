using System;

namespace ApiTaqueria.Models
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTimeOffset Expiration { get; set; }
    }
}
