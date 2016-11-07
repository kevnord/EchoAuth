using System;
using System.Threading.Tasks;
using EchoAuth.Core.Engines;
using EchoAuth.Core.Models;
using EchoAuth.Core.Models.AccessTokens;

namespace EchoAuth.Core.Managers
{
    /// <summary>
    /// Responsible for processing Authorization Code Grant and Implicit Grant requests. Methods are used by /authorize endpoint
    /// </summary>
    public class AuthorizationManager : IAuthorizationManager
    {
        private readonly IClientAuthenticationEngine _clientAuthenticationEngine;
        private readonly IAuthorizationDataValidatorEngine _authorizationDataValidatorEngine;

        public AuthorizationManager(IClientAuthenticationEngine clientAuthenticationEngine, IAuthorizationDataValidatorEngine authorizationDataValidatorEngine)
        {
            _clientAuthenticationEngine = clientAuthenticationEngine;
            _authorizationDataValidatorEngine = authorizationDataValidatorEngine;
        }

        public async Task<TokenResponse<AuthorizationCodeResponse>> AuthorizationCode(string clientId, Uri redirectUri = null, string scope = null, string state = null)
        {
            if (string.IsNullOrWhiteSpace(clientId))
            {
                return TokenResponse<AuthorizationCodeResponse>.Create(TokenErrorCode.InvalidRequest, "Invalid clientId");
            }

            if (!await _clientAuthenticationEngine.Authenticate(clientId, redirectUri))
            {
                return TokenResponse<AuthorizationCodeResponse>.Create(TokenErrorCode.InvalidClient, null);
            }

            //            var code = await _authorizationDataValidatorEngine.Generate(clientId, null, scope, redirectUri);

            //            var response = new AuthorizationCodeResponse { Code = code, State = state };

            //            return TokenResponse<AuthorizationCodeResponse>.Create(response);

            throw new NotImplementedException();
        }

        public async Task<TokenResponse<ImplicitGrantResponse>> ImplicitGrant(string clientId, Uri redirectUri = null, string scope = null, string state = null)
        {
            if (string.IsNullOrWhiteSpace(clientId))
            {
                return TokenResponse<ImplicitGrantResponse>.Create(TokenErrorCode.InvalidRequest, "Invalid clientId", state);
            }

            if (!await _clientAuthenticationEngine.Authenticate(clientId, redirectUri))
            {
                return TokenResponse<ImplicitGrantResponse>.Create(TokenErrorCode.AccessDenied, null, state);
            }

            throw new NotImplementedException();

            //var code = await _authorizationDataValidatorEngine.Generate(clientId, redirectUri);

            //var response = new ImplicitGrantResponse { AccessToken = code, State = state };

            //return TokenResponse<ImplicitGrantResponse>.Create(response);
        }
    }
}