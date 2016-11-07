using System;
using System.Threading.Tasks;

namespace EchoAuth.Core.Engines
{
    public interface IClientAuthenticationEngine
    {
        Task<bool> Authenticate(string clientId, string clientSecret);
        Task<bool> Authenticate(string clientId, Uri redirectUri);
    }
}
