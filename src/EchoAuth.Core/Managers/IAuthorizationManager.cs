using System;
using System.Threading.Tasks;
using EchoAuth.Core.Models;
using EchoAuth.Core.Models.AccessTokens;

namespace EchoAuth.Core.Managers
{
    public interface IAuthorizationManager
    {
        Task<AuthResult<AuthorizationCodeResponse>> AuthorizationCode(string clientId, Uri redirectUri = null, string scope = null, string state = null);
        Task<AuthResult<ImplicitGrantResponse>> ImplicitGrant(string clientId, Uri redirectUri, string scope, string state);
    }
}
