using System;

namespace EchoAuth.Core.Models
{
    public class AuthorizationResponse<T>
    {
        public Error<AuthorizationErrorCode> Error { get; set; }
        public T Result { get; set; }

        public static AuthorizationResponse<T> Create(AuthorizationErrorCode errorCode, string errorDescription = null,
            string state = null, Uri errorUri = null)
        {
            return new AuthorizationResponse<T>
            {
                Error = new Error<AuthorizationErrorCode>
                {
                    ErrorCode = errorCode,
                    ErrorDescription = errorDescription,
                    ErrorUri = errorUri,
                    State = state
                }
            };
        }

        public static AuthorizationResponse<T> Create(T result)
        {
            return new AuthorizationResponse<T> { Result = result };
        }
    }
}