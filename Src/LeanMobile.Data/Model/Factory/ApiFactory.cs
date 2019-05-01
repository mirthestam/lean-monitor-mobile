using System;
using System.Net.Http;
using Newtonsoft.Json;
using Refit;

namespace LeanMobile.Data.Model.Factory
{
    public class ApiFactory : IApiFactory
    {
        public IApi Create(string authUserToken, string authAccessToken, string endpointAddress)
        {
            var httpClientHandler = new AuthenticatedHttpClientHandler(authUserToken, authAccessToken);

            var httpClient = new HttpClient(httpClientHandler)
            {
                BaseAddress = new Uri(endpointAddress)
            };

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.None
            };

            var contentSerializer = new JsonContentSerializer(jsonSerializerSettings);

            var refitSettings = new RefitSettings
            {
                ContentSerializer = contentSerializer
            };

            return RestService.For<IApi>(httpClient, refitSettings);
        }
    }
}