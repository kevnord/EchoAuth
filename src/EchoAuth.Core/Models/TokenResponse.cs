using System;

namespace EchoAuth.Core.Models
{
    public class TokenResponse<T>
    {
        public Error<TokenErrorCode> Error { get; set; }
        public T Result { get; set; }

        public static TokenResponse<T> Create(TokenErrorCode errorCode, string errorDescription = null,
            string state = null, Uri errorUri = null)
        {
            return new TokenResponse<T>
            {
                Error = new Error<TokenErrorCode>
                {
                    ErrorCode = errorCode,
                    ErrorDescription = errorDescription,
                    ErrorUri = errorUri,
                    State = state
                }
            };
        }

        public static TokenResponse<T> Create(T result)
        {
            return new TokenResponse<T> { Result = result };
        }
    }
}
