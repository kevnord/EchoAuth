using System;
using System.Threading.Tasks;
using EchoAuth.Core.Engines;
using EchoAuth.Core.Models;
using EchoAuth.Core.Models.AccessTokens;
using EchoAuth.Core.Resources;
using EchoAuth.Core.Utilities;

namespace EchoAuth.Core.Managers
{
    /// <summary>
    /// Responsible for processing (Access) Token requests. Methods are used by /token endpoint
    /// </summary>
    public class TokenManager : ITokenManager
    {
        private readonly IClientAuthenticationEngine _clientAuthenticationEngine;
        private readonly IUserAuthenticationEngine _userAuthenticationEngine;
        private readonly IUserClientAuthorizationResourceAccess _userClientAuthorizationResourceAccess;
        private readonly IAuthorizationDataValidatorEngine _authorizationDataValidatorEngine;
        private readonly IAuthorizationCodeEncoderEngine _authorizationCodeEncoderEngine;
        private readonly IDateTimeProvider _dateTimeProvider;

        public TokenManager(IClientAuthenticationEngine clientAuthenticationEngine, IAuthorizationDataValidatorEngine authorizationDataValidatorEngine, IAuthorizationCodeEncoderEngine authorizationCodeEncoderEngine, IUserClientAuthorizationResourceAccess userClientAuthorizationResourceAccess, IDateTimeProvider dateTimeProvider)
        {
            _clientAuthenticationEngine = clientAuthenticationEngine;
            _authorizationDataValidatorEngine = authorizationDataValidatorEngine;
            _authorizationCodeEncoderEngine = authorizationCodeEncoderEngine;
            _userClientAuthorizationResourceAccess = userClientAuthorizationResourceAccess;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<TokenResponse<AuthorizationCodeGrantResponse>> AuthorizationCodeGrant(string code, string clientId, string clientSecret = null, Uri redirectUri = null)
        {
            // Check Parameters

            if (string.IsNullOrWhiteSpace(code))
                return TokenResponse<AuthorizationCodeGrantResponse>.Create(TokenErrorCode.InvalidRequest, "Invalid code");
            if (string.IsNullOrWhiteSpace(clientId))
                return TokenResponse<AuthorizationCodeGrantResponse>.Create(TokenErrorCode.InvalidRequest, "Invalid client_id");
            if (string.IsNullOrWhiteSpace(clientSecret))
                return TokenResponse<AuthorizationCodeGrantResponse>.Create(TokenErrorCode.InvalidRequest, "Invalid client_secret");

            // Authenticate Client

            if (!await _clientAuthenticationEngine.Authenticate(clientId, clientSecret))
            {
                return TokenResponse<AuthorizationCodeGrantResponse>.Create(TokenErrorCode.InvalidClient, "Invalid client_id");
            }

            // Authorize Client and Scope for user
            AuthorizationData authorizationData;
            if (!_authorizationCodeEncoderEngine.TryDecode(code, out authorizationData) ||
                !await _authorizationDataValidatorEngine.IsValid(authorizationData, clientId, redirectUri))
            {
                return TokenResponse<AuthorizationCodeGrantResponse>.Create(TokenErrorCode.InvalidGrant, "Invalid authorization_code");
            }

            // Create AccessToken
            var expiration = _dateTimeProvider.NowUtc;

            var response = AuthorizationCodeGrantResponse.Create(clientId,
                authorizationData.UserId,
                authorizationData.Scope,
                expiration);

            // Wrap AccessToken
            return TokenResponse<AuthorizationCodeGrantResponse>.Create(response);
        }

        public async Task<TokenResponse<ClientCredentialGrantResponse>> ClientCredentialGrant(string clientId, string clientSecret, string scope)
        {
            throw new NotImplementedException();
        }

        public async Task<TokenResponse<PasswordGrantResponse>> PasswordGrant(string clientId, string clientSecret, string username, string password, string scope = null)
        {
            if (await _clientAuthenticationEngine.Authenticate(clientId, clientSecret))
            {
                User user;
                if (await _userAuthenticationEngine.Authenticate(username, password, out user))
                {
                    var userId = user.UserId;
                    await _userClientAuthorizationResourceAccess.AuthorizeClient(userId, clientId, scope);

                    var authorizationInformation = new AuthorizationData();
                    var accessToken = await _authorizationCodeEncoderEngine.Encode(authorizationInformation);

                    var passwordGrantResponse = new PasswordGrantResponse
                    {
                        AccessToken = accessToken,
                        ExpiresIn = 0,
                        RefreshToken = null
                    };

                    return TokenResponse<PasswordGrantResponse>.Create(passwordGrantResponse);
                }
                else
                {
                    return TokenResponse<PasswordGrantResponse>.Create(TokenErrorCode.AccessDenied, "unauthorized");
                }
            }
            else
            {
                return TokenResponse<PasswordGrantResponse>.Create(TokenErrorCode, i, "unauthorized");
            }

        }

        public async Task<TokenResponse<RefreshTokenGrantResponse>> RefreshTokenGrant(string clientId, string clientSecret, string refreshToken, string scope)
        {
            throw new NotImplementedException();
        }
    }
}