using System;
using System.Threading.Tasks;
using EchoAuth.Core.Models;

namespace EchoAuth.Core.Engines
{
    public interface IAccessTokenProviderEngine
    {
        Task<string> Generate(string clientId, string userId, Uri redirectUri);

        Task<AuthorizationCode> Deconstruct(string code);
    }
}