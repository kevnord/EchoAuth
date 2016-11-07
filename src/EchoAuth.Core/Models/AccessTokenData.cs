using System;

namespace EchoAuth.Core.Managers
{
    public class AccessTokenData
    {
        public string ClientId { get; set; }
        public string UserId { get; set; }
        public string Scope { get; set; }
        public DateTime Expiration { get; set; }

        public static AccessTokenData Create(string clientId, string userId, string scope, DateTime expiration)
        {
            return new AccessTokenData
            {
                ClientId = clientId,
                UserId = userId,
                Scope = scope,
                Expiration = expiration
            };
        }
    }
}