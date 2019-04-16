using System;
using System.Net.Http;
using Fusillade;
using Refit;

namespace LeanMobile.Data.Remote.Factory
{
    public class ApiFactory : IApiFactory
    {
        public IApi Create(string authUserToken, string authAccessToken, string endpointAddress)
        {
            var httpClientHandler = new AuthenticatedHttpClientHandler(authUserToken, authAccessToken);
            //var httpMessageHandler = new RateLimitedHttpMessageHandler(httpClientHandler, Priority.UserInitiated);

            var httpClient = new HttpClient(httpClientHandler)
            {
                BaseAddress = new Uri(endpointAddress)
            };

            return RestService.For<IApi>(httpClient);

        }
    }
}