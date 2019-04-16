using System.Threading.Tasks;
using LeanMobile.Authentication;
using LeanMobile.Settings;

namespace LeanMobile.Data.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        // TODO: Implement this as a provider, and let the service live in LeanMobile
        private readonly ISettingsService _settingsService;
        private readonly IApiFactory _apiFactory;

        public AuthenticationService(ISettingsService settingsService, IApiFactory apiFactory)
        {
            _settingsService = settingsService;
            _apiFactory = apiFactory;
        }

        public async Task<bool> IsAuthenticated(string authUserToken, string authAccessToken)
        {
            try
            {
                // Create a new API we can use to test the credentials with
                var api = _apiFactory.Create(authUserToken, authAccessToken, _settingsService.EndpointAddress);

                //  Await whether we are authenticated
                var response = await api.GetAuthenticateAsync();
                return response.Success;
            }
            catch
            {
                return false;
            }
        }

        public bool HasCredentials
        {
            get
            {
                var authAccessToken = _settingsService.AuthAccessToken;
                var AuthUserToken = _settingsService.AuthUserToken;
                return !string.IsNullOrWhiteSpace(authAccessToken + AuthUserToken);
            }
        }
    }
}