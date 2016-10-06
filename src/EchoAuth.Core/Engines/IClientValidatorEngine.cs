using System;
using System.Threading.Tasks;

namespace EchoAuth.Core.Engines
{
    public interface IClientValidatorEngine
    {
        Task<bool> IsValidClient(string clientId, string clientSecret);
        Task<bool> IsValidClient(string clientId, Uri redirectUri);
    }
}
