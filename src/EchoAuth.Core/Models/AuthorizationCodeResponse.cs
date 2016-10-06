using Newtonsoft.Json;

namespace EchoAuth.Core.Models
{
    public class AuthorizationCodeResponse
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
    }
}
