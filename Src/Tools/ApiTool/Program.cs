using System;
using System.Net.Http;
using System.Threading.Tasks;
using LeanMobile.Data.Remote;
using LeanMobile.Data.Remote.Factory;
using Refit;

namespace ApiTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var tool = new Tool();
            tool.Run().Wait();
        }
    }

    public class Tool
    {
        private IApi _api;

        public async Task Run()
        {
            const string authUserToken = "***REMOVED***";
            const string authAccessToken = "***REMOVED***";
            const string endpointAddress = "https://www.quantconnect.com/api/v2";

            const int projectId = 2416667;
            const string deployId = "L-82bee18752ab30d0c0705bf1962e6e9d";

            _api = Create(authUserToken, authAccessToken, endpointAddress);

            //var liveAlgorithmResponse = await _api.GetLiveAlgorithmListAsync();
            var liveAlgorithmResultsResponse = await _api.GetLiveAlgorithmResultsAsync(projectId, deployId);
            //var logsResponse = await _api.GetLiveAlgorithmLogs(projectId, deployId);
            //var projectsResponse = await _api.GetProjectsAsync();
            //var projectResponse = await _api.GetProjectAsync(projectId).ConfigureAwait(false);
        }

        public IApi Create(string authUserToken, string authAccessToken, string endpointAddress)
        {
            var httpClientHandler = new AuthenticatedHttpClientHandler(authUserToken, authAccessToken);
            var messageLoggingHandler = new LoggingHandler(httpClientHandler);

            var httpClient = new HttpClient(messageLoggingHandler)
            {
                BaseAddress = new Uri(endpointAddress)
            };

            return RestService.For<IApi>(httpClient);
        }
    }
}
