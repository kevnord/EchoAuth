﻿using Newtonsoft.Json;

namespace EchoAuth.Core.Models.AccessTokens
{
    public class PasswordGrantResponse
    {
        [JsonProperty("token_type")]
        public TokenType TokenType { get; private set; } = TokenType.Bearer;
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}