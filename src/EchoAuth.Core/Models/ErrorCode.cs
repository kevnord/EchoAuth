using Newtonsoft.Json;

namespace EchoAuth.Core.Models
{
    public enum ErrorCode
    {
        NotSet,
        [JsonProperty("invalid_request")]
        InvalidRequest,
        [JsonProperty("unauthorized_client")]
        UnauthorizedClient,
        [JsonProperty("access_denied")]
        AccessDenied,
        [JsonProperty("unsupported_response_type")]
        UnsupportedResponseType,
        [JsonProperty("invalid_scope")]
        InvalidScope,
        [JsonProperty("server_error")]
        ServerError,
        [JsonProperty("temporarily_unavailable")]
        TemporarilyUnavailable
    }
}