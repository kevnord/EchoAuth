using System;

namespace EchoAuth.Core.Models
{
    public class AuthResult<T>
    {
        public Error Error { get; set; }
        public T Result { get; set; }

        public static AuthResult<T> Create(ErrorCode errorCode, string errorDescription = null, string state = null, Uri errorUri = null)
        {
            return new AuthResult<T>
            {
                Error = new Error
                {
                    ErrorCode = errorCode,
                    ErrorDescription = errorDescription,
                    ErrorUri = errorUri,
                    State = state
                }
            };
        }

        public static AuthResult<T> Create(T result)
        {
            return new AuthResult<T> { Result = result };
        }
    }
}