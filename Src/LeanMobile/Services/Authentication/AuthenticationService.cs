using System;
using System.Linq;
using System.Threading.Tasks;
using LeanMobile.Services.Api;
using LeanMobile.Services.Settings;
using QuantConnect.Api;
using QuantConnect.Api.Factory;

namespace LeanMobile.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
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
    }
}