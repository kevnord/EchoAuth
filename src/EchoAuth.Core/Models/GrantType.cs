using Newtonsoft.Json;

namespace EchoAuth.Core.Models
{
    public enum GrantType
    {
        [JsonProperty("not-set")]
        NotSet,
        [JsonProperty("password")]
        Password
    }
}
