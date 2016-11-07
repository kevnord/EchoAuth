using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using EchoAuth.Core.Managers;
using EchoAuth.Core.Models;
using EchoAuth.Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EchoAuth.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IAuthorizationManager _authorizationManager;
        private readonly ITokenManager _tokenManager;
        private readonly ISerializatiion _serializatiion;

        public AuthorizationController(IAuthorizationManager authorizationManager, ITokenManager tokenManager, ISerializatiion serializatiion)
        {
            _authorizationManager = authorizationManager;
            _tokenManager = tokenManager;
            _serializatiion = serializatiion;
        }

        [HttpPost("token")]
        public async Task<IActionResult> Token(GrantType grantType, string username, string password, string scope)
        {
            string clientId;
            string clientSecret;

            RetrieveAuthorization(out clientId, out clientSecret);

            switch (grantType)
            {
                case GrantType.Password:
                    var token = await _tokenManager.PasswordGrant(clientId, clientSecret, scope, username, password);



                    if (token.Error == null)
                    {
                        return Ok(token.Result);
                    }

                    switch (token.Error.TokenErrorCode)
                    {
                        case TokenErrorCode.InvalidRequest:
                            return BadRequest(token.Error);
                        case TokenErrorCode.UnauthorizedClient:
                            var message = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                            { Content = new JsonContent(_serializatiion.Serialize(token.Error)) };

//HttpStatusCode                        case TokenErrorCode.AccessDenied:
                            break;
                        case TokenErrorCode.UnsupportedResponseType:
                            break;
                        case TokenErrorCode.InvalidScope:
                            break;
                        case TokenErrorCode.ServerError:
                            break;
                        case TokenErrorCode.TemporarilyUnavailable:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    else
                    {
                        return this.Unauthorized();
                    }


                    break;
                default:
                    //TODO: Return not supported
                    throw new ArgumentOutOfRangeException(nameof(grantType), grantType, null);
            }



            throw new NotImplementedException();
        }

        private void RetrieveAuthorization(out string clientId, out string clientSecret)
        {
            throw new NotImplementedException();
        }
    }

    public class JsonContent : HttpContent
    {
        private readonly JToken _value;

        public JsonContent(JToken value)
        {
            _value = value;
            Headers.ContentType = new MediaTypeHeaderValue("application/json");
        }

        protected override Task SerializeToStreamAsync(Stream stream,
            TransportContext context)
        {
            var jw = new JsonTextWriter(new StreamWriter(stream))
            {
                Formatting = Formatting.Indented
            };
            _value.WriteTo(jw);
            jw.Flush();
            return Task.FromResult<object>(null);
        }

        protected override bool TryComputeLength(out long length)
        {
            length = -1;
            return false;
        }
    }
}
