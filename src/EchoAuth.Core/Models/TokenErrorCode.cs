using Newtonsoft.Json;

namespace EchoAuth.Core.Models
{
    public enum TokenErrorCode
    {
        [JsonProperty("none")]
        None,
        [JsonProperty("invalid_request")]
        InvalidRequest,
        [JsonProperty("invalid_client")]
        InvalidClient,
        [JsonProperty("invalid_grant")]
        InvalidGrant,
        [JsonProperty("unauthorized_client")]
        UnauthorizedClient,
        [JsonProperty("unsupported_grant_type")]
        UnsupportedGrantType,
        [JsonProperty("invalid_scope")]
        InvalidScope
    }
}