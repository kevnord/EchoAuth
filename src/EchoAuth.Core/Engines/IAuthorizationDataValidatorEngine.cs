using System;
using System.Threading.Tasks;
using EchoAuth.Core.Models;

namespace EchoAuth.Core.Engines
{
    public interface IAuthorizationDataValidatorEngine
    {
        /// <summary>
        /// ensure that the authorization code was issued to the authenticated
        /// confidential client, or if the client is public, ensure that the
        /// code was issued to "client_id" in the request,
        /// </summary>
        /// <param name="authorizationData">Authorization Data</param>
        /// <param name="clientId">clientId (client_id)</param>
        /// <param name="redirectUri">redirectUri used to obtain AuthorizationCode. Or empty if one was not used.</param>
        /// <returns></returns>
        Task<bool> IsValid(AuthorizationData authorizationData, string clientId, Uri redirectUri = null);
    }
}