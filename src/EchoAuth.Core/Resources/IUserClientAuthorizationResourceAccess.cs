using System.Threading.Tasks;

namespace EchoAuth.Core.Resources
{
    public interface IUserClientAuthorizationResourceAccess
    {
        Task AuthorizeClient(string userId, string clientId, string scope);
    }
}
