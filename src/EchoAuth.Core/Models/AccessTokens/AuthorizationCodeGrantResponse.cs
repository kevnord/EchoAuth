using System;
using EchoAuth.Core.Managers;
using EchoAuth.Core.Utilities;
using Newtonsoft.Json;

namespace EchoAuth.Core.Models.AccessTokens
{
    public class AuthorizationCodeGrantResponse
    {
        [JsonProperty("token_type")]
        public TokenType TokenType { get; private set; } = TokenType.Bearer;
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        public static AuthorizationCodeGrantResponse Create(string clientId, string userId, string scope, DateTime expiration)
        {
            var data = new AccessTokenData
            {
                UserId = userId,
                ClientId = clientId,
                Scope = scope,
                Expiration = expiration
            };


            var response = new AuthorizationCodeGrantResponse
            {
               AccessToken = Serialization.Singleton.Serialize(data, "");
            };

            return response;
        }
    }
}