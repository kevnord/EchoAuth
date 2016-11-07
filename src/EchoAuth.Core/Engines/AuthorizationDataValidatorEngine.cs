using System;
using System.Threading.Tasks;
using EchoAuth.Core.Models;
using EchoAuth.Core.Utilities;

namespace EchoAuth.Core.Engines
{
    public class AuthorizationDataValidatorEngine : IAuthorizationDataValidatorEngine
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public AuthorizationDataValidatorEngine(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public Task<bool> IsValid(AuthorizationData authorizationData, string clientId, Uri redirectUri = null)
        {
            if (clientId != authorizationData.ClientId
                || redirectUri != authorizationData.RedirectUri
                || _dateTimeProvider.NowUtc > authorizationData.Expiration)
            {
                return false;
            }

            //if (redirectUri !=



            throw new NotImplementedException();
        }
    }
}