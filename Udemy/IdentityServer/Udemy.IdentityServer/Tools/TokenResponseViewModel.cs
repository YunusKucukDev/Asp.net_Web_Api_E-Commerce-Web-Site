using System;

namespace Udemy.IdentityServer.Tools
{
    public class TokenResponseViewModel
    {
        public TokenResponseViewModel(string token, DateTime expireTime)
        {
            Token = token;
            ExpireTime = expireTime;
        }

        public string Token { get; set; }
        public DateTime  ExpireTime { get; set; }
    }
}
