using System;
using Newtonsoft.Json;

namespace EchoAuth.Core.Models
{
    public class AuthorizationData
    {
        [JsonProperty("client_id")]
        public string ClientId { get; set; }
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("redirect_uri")]
        public Uri RedirectUri { get; set; }
        [JsonProperty("scope")]
        public string Scope { get; set; }
        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }
    }
}