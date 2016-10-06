using System;
using System.Threading.Tasks;
using EchoAuth.Core.Models;

namespace EchoAuth.Core.Engines
{
    public interface IAuthorizationCodeProviderEngine
    {
        Task<AuthorizationCode> Deconstruct(string code);
        Task<bool> IsValidCode(string code, string clientId, Uri redirectUri);
        Task Generate(string clientId, string userId, string scope, Uri redirectUri);
    }
}