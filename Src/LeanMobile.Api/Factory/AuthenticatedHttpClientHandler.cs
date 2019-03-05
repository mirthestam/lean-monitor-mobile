using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LeanMobile.Utils;

namespace QuantConnect.Api.Factory
{
    public class AuthenticatedHttpClientHandler : HttpClientHandler
    {
        private readonly string _userToken;
        private readonly string _authenticationToken;

        public AuthenticatedHttpClientHandler(string userToken, string authenticationToken)
        {
            _userToken = userToken;
            _authenticationToken = authenticationToken;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)        
        {            
            // Authentication is based upon logic found in Lean
            // QuantConnect.Api.ApiConnection.TryRequest<T>
            var timeStamp = (int)DateTime.UtcNow.ToUnixTimeStamp();

            // Add the timestamp header            
            if (request.Headers.Contains("Timestamp"))
            {
                throw new Exception("Timestamp header has already been set");
            }
            request.Headers.Add("Timestamp", timeStamp.ToString(CultureInfo.InvariantCulture));

            // Add the authentication header
            var hash = CreateHash(timeStamp, _authenticationToken);
            var encodedAuthenticationString = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_userToken}:{hash}"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", encodedAuthenticationString);

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }

        private static string CreateHash(int timeStamp, string authenticationToken)
        {
            var data = $"{authenticationToken}:{timeStamp}";

            var crypt = new SHA256Managed();
            var hashString = new StringBuilder();
            var hash = crypt.ComputeHash(Encoding.UTF8.GetBytes(data), 0, Encoding.UTF8.GetByteCount(data));
            foreach (var theByte in hash)
            {
                hashString.Append(theByte.ToString("x2"));
            }
            return hashString.ToString();

        }
    }
}