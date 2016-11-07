using System.Threading.Tasks;
using EchoAuth.Core.Models;

namespace EchoAuth.Core.Engines
{
    public interface IAuthorizationCodeEncoderEngine
    {
        Task<string> Encode(AuthorizationData authorizationData);

        bool TryDecode(string authorizationCode, out AuthorizationData result);
    }
}