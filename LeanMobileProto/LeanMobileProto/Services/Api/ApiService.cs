using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Fusillade;
using LeanMobileProto.Services.Settings;
using Refit;

namespace LeanMobileProto.Services.Api
{
    public class ApiService : IApiService
    {
        private readonly ISettingsService _settingsService;

        private readonly Lazy<IApi> _backgroundApi;
        private readonly Lazy<IApi> _userInitiatedApi;
        private readonly Lazy<IApi> _speculativeApi;

        public ApiService(ISettingsService settingsService)
        {
            _settingsService = settingsService;

            var handler = new HttpClientHandler();

            _backgroundApi = new Lazy<IApi>(() => Create(Priority.Background));
            _userInitiatedApi = new Lazy<IApi>(() => Create(Priority.UserInitiated));
            _speculativeApi = new Lazy<IApi>(() => Create(Priority.Speculative));
        }

        private IApi Create(Priority priority)
        {
            var clientHandler = new HttpClientHandler();
            var messageHandler = new RateLimitedHttpMessageHandler(new HttpClientHandler(), priority);
            var client = new HttpClient(messageHandler)
            {
                BaseAddress = new Uri(_settingsService.EndpointAddress)
            };

            return RestService.For<IApi>(client);
        }

        public IApi Background => _backgroundApi.Value;
        public IApi UserInitiated => _userInitiatedApi.Value;
        public IApi Speculative => _speculativeApi.Value;

        public IApi ForPriority(Priority priority)
        {
            switch (priority)
            {
                case Priority.Speculative:
                    return Speculative;
                    
                case Priority.UserInitiated:
                    return UserInitiated;
                    
                case Priority.Background:
                    return Background;

                default:
                    throw new ArgumentOutOfRangeException(nameof(priority), priority, null);
            }   
        }
    }
}
