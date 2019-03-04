﻿using System;
using System.Net.Http;
using Fusillade;
using LeanMobileProto.Services.Api;
using Refit;

namespace LeanMobileProto.Model.Api
{
    public class ApiFactory : IApiFactory
    {
        public IApi Create(string authUserToken, string authAccessToken, string endpointAddress)
        {
            var httpClientHandler = new AuthenticatedHttpClientHandler(authUserToken, authAccessToken);
            var httpMessageHandler = new RateLimitedHttpMessageHandler(httpClientHandler, Priority.UserInitiated);

            var httpClient = new HttpClient(httpMessageHandler)
            {
                BaseAddress = new Uri(endpointAddress)
            };

            return RestService.For<IApi>(httpClient);

        }
    }
}