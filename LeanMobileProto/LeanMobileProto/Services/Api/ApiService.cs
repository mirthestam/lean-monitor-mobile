﻿using System;
using System.Collections.Generic;
using System.Text;
using LeanMobileProto.Model.Api;
using LeanMobileProto.Services.Settings;

namespace LeanMobileProto.Services.Api
{
    public class ApiService : IApiService
    {
        private readonly ISettingsService _settingsService;
        private readonly IApiFactory _apiFactory;
        
        private Lazy<IApi> _api;

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