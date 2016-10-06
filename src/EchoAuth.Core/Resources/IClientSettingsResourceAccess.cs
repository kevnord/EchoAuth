using System.Threading.Tasks;
using EchoAuth.Core.Models;

namespace EchoAuth.Core.Resources
{
    public interface IClientSettingsResourceAccess
    {
        Task<ClientSettings> GetClientSettings(string clientId);
    }
}
