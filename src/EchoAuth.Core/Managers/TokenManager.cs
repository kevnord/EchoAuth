using System;
using System.Threading.Tasks;
using EchoAuth.Core.Engines;
using EchoAuth.Core.Models;
using EchoAuth.Core.Models.AccessTokens;

namespace EchoAuth.Core.Managers
{
    public class TokenManager : ITokenManager
    {
        private readonly IClientValidatorEngine _clientValidatorEngine;
        private readonly IAuthorizationCodeProviderEngine _authorizationCodeProviderEngine;
        private readonly IAccessTokenProviderEngine _accessTokenProviderEngine;

        public TokenManager(IClientValidatorEngine clientValidatorEngine, IAuthorizationCodeProviderEngine authorizationCodeProviderEngine, IAccessTokenProviderEngine accessTokenProviderEngine)
        {
            _clientValidatorEngine = clientValidatorEngine;
            _authorizationCodeProviderEngine = authorizationCodeProviderEngine;
            _accessTokenProviderEngine = accessTokenProviderEngine;
        }

        public async Task<AuthResult<AuthorizationCodeGrantResponse>> AuthorizationCodeGrant(string clientId, string clientSecret, Uri redirectUri, string code)
        {
            if (string.IsNullOrWhiteSpace(clientId))
            {
                return AuthResult<AuthorizationCodeGrantResponse>.Create(ErrorCode.InvalidRequest, "Invalid clientId");
            }

            if (string.IsNullOrWhiteSpace(clientSecret))
            {
                return AuthResult<AuthorizationCodeGrantResponse>.Create(ErrorCode.InvalidRequest, "Invalid clientSecret");
            }

            if (redirectUri == null || !redirectUri.IsAbsoluteUri)
            {
                return AuthResult<AuthorizationCodeGrantResponse>.Create(ErrorCode.InvalidRequest, "Invalid redirectUri");
            }

            if (string.IsNullOrWhiteSpace(code))
            {
                return AuthResult<AuthorizationCodeGrantResponse>.Create(ErrorCode.InvalidRequest, "Invalid code");
            }


           if (!await _clientValidatorEngine.IsValidClient(clientId, clientSecret))
            {
                return AuthResult<AuthorizationCodeGrantResponse>.Create(ErrorCode.UnauthorizedClient, "Invalid clientId");
            }

            if (!await _authorizationCodeProviderEngine.IsValidCode(code, clientId, redirectUri))
            {
                return AuthResult<AuthorizationCodeGrantResponse>.Create(ErrorCode.AccessDenied, "Invalid clientId");
            }

            var authorizationCode = await _authorizationCodeProviderEngine.Deconstruct(code);

            //return await _accessTokenGeneratorEngine.Generate(clientId, authorizationCode.UserId, authorizationCode.Scope, );


            throw new NotImplementedException();
        }

        public async Task<AuthResult<ClientCredentialGrantResponse>> ClientCredentialGrant(string clientId, string clientSecret, string scope)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResult<PasswordGrantResponse>> PasswordGrant(string clientId, string clientSecret, string scope, string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResult<RefreshTokenGrantResponse>> RefreshTokenGrant(string clientId, string clientSecret, string refreshToken, string scope)
        {
            throw new NotImplementedException();
        }
    }
}