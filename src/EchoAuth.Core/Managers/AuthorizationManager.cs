using System;
using System.Threading.Tasks;
using EchoAuth.Core.Engines;
using EchoAuth.Core.Models;
using EchoAuth.Core.Models.AccessTokens;

namespace EchoAuth.Core.Managers
{
    public class AuthorizationManager : IAuthorizationManager
    {
        private readonly IClientValidatorEngine _clientValidatorEngine;
        private readonly IAuthorizationCodeProviderEngine _authorizationCodeProviderEngine;

        public AuthorizationManager(IClientValidatorEngine clientValidatorEngine, IAuthorizationCodeProviderEngine authorizationCodeProviderEngine)
        {
            _clientValidatorEngine = clientValidatorEngine;
            _authorizationCodeProviderEngine = authorizationCodeProviderEngine;
        }

        public async Task<AuthResult<AuthorizationCodeResponse>> AuthorizationCode(string clientId, Uri redirectUri = null, string scope = null)
        {
            if (string.IsNullOrWhiteSpace(clientId))
            {
                return AuthResult<AuthorizationCodeResponse>.Create(ErrorCode.InvalidRequest, "Invalid clientId");
            }

            if (!await _clientValidatorEngine.IsValidClient(clientId, redirectUri))
            {
                return AuthResult<AuthorizationCodeResponse>.Create(ErrorCode.AccessDenied, null);
            }

            //            var code = await _authorizationCodeProviderEngine.Generate(clientId, null, scope, redirectUri);

            //            var response = new AuthorizationCodeResponse { Code = code, State = state };

            //            return AuthResult<AuthorizationCodeResponse>.Create(response);

            throw new NotImplementedException();
        }

        public Task<AuthResult<AuthorizationCodeResponse>> AuthorizationCode(string clientId, Uri redirectUri = null, string scope = null, string state = null)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResult<ImplicitGrantResponse>> ImplicitGrant(string clientId, Uri redirectUri = null, string scope = null, string state = null)
        {
            if (string.IsNullOrWhiteSpace(clientId))
            {
                return AuthResult<ImplicitGrantResponse>.Create(ErrorCode.InvalidRequest, "Invalid clientId", state);
            }

            if (!await _clientValidatorEngine.IsValidClient(clientId, redirectUri))
            {
                return AuthResult<ImplicitGrantResponse>.Create(ErrorCode.AccessDenied, null, state);
            }

            throw new NotImplementedException();

            //var code = await _authorizationCodeProviderEngine.Generate(clientId, redirectUri);

            //var response = new ImplicitGrantResponse { AccessToken = code, State = state };

            //return AuthResult<ImplicitGrantResponse>.Create(response);
        }
    }
}