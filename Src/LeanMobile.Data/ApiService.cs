using System;
using LeanMobile.Data.Model;
using LeanMobile.Settings;

namespace LeanMobile.Data
{
    public class ApiService : IApiService
    {
        private readonly ISettingsService _settingsService;
        private readonly IApiFactory _apiFactory;

        private readonly Lazy<IApi> _api;

        public IApi Api => _api.Value;

        public ApiService(ISettingsService settingsService, IApiFactory apiFactory)
        {
            _settingsService = settingsService;
            _apiFactory = apiFactory;
            _api = new Lazy<IApi>(CreateApi);
        }

        private IApi CreateApi()
        {
            return _apiFactory.Create(_settingsService.AuthUserToken, _settingsService.AuthAccessToken, _settingsService.EndpointAddress);
        }
    }
}