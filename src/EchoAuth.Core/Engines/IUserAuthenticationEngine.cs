using System.Threading.Tasks;
using EchoAuth.Core.Models;

namespace EchoAuth.Core.Engines
{
    public interface IUserAuthenticationEngine
    {
        Task<bool> Authenticate(string username, string password, out User user);
    }
}