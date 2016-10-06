using System;
using System.Threading.Tasks;
using EchoAuth.Core.Models;
using EchoAuth.Core.Models.AccessTokens;

namespace EchoAuth.Core.Managers
{
    public interface ITokenManager
    {
        Task<AuthResult<AuthorizationCodeGrantResponse>> AuthorizationCodeGrant(string clientId, string clientSecret, Uri redirectUri, string code);
        Task<AuthResult<ClientCredentialGrantResponse>> ClientCredentialGrant(string clientId, string clientSecret, string scope);
        Task<AuthResult<PasswordGrantResponse>> PasswordGrant(string clientId, string clientSecret, string scope, string username, string password);
        Task<AuthResult<RefreshTokenGrantResponse>> RefreshTokenGrant(string clientId, string clientSecret, string refreshToken, string scope);
    }
}
