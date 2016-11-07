using System;
using System.Threading.Tasks;
using EchoAuth.Core.Models;
using EchoAuth.Core.Models.AccessTokens;

namespace EchoAuth.Core.Managers
{
    public interface ITokenManager
    {
        Task<TokenResponse<AuthorizationCodeGrantResponse>> AuthorizationCodeGrant(string clientId, string clientSecret, Uri redirectUri, string code);
        Task<TokenResponse<ClientCredentialGrantResponse>> ClientCredentialGrant(string clientId, string clientSecret, string scope);
        Task<TokenResponse<PasswordGrantResponse>> PasswordGrant(string clientId, string clientSecret, string scope, string username, string password);
        Task<TokenResponse<RefreshTokenGrantResponse>> RefreshTokenGrant(string clientId, string clientSecret, string refreshToken, string scope);
    }
}
