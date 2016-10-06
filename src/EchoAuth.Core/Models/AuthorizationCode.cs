using System;
using Newtonsoft.Json;

namespace EchoAuth.Core.Models
{
    public class AuthorizationCode
    {
        [JsonProperty("c")]
        public string ClientId { get; set; }
        [JsonProperty("u")]
        public string UserId { get; set; }
        [JsonProperty("r")]
        public Uri RedirectUri { get; set; }
        [JsonProperty("s")]
        public string Scope { get; set; }
    }
}