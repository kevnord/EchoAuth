using System;
using Newtonsoft.Json;

namespace EchoAuth.Core.Models
{
    public class Error<TErrorCode>
    {
        [JsonProperty("error_code")]
        public TErrorCode ErrorCode { get; set; }
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
        [JsonProperty("error_uri")]
        public Uri ErrorUri { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
    }
}
