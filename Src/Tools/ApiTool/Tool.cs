using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LeanMobile.Algorithms.Results;
using LeanMobile.Data.Algorithm;
using LeanMobile.Data.Model;
using LeanMobile.Data.Model.Factory;
using Refit;

namespace ApiTool
{

    public class Tool
    {
        private IApi _api;

        public async Task Run()
        {
            const string authUserToken = "***REMOVED***";
            const string authAccessToken = "***REMOVED***";
            const string endpointAddress = "https://www.quantconnect.com/api/v2";

            //const int projectId = 2416667;
            const int projectId = 530955;
            //const string deployId = "L-82bee18752ab30d0c0705bf1962e6e9d";
            const string deployId = "L-c69ee5e5557ddc525532d9fd9dd4b2f7";

            _api = Create(authUserToken, authAccessToken, endpointAddress);

            var liveAlgorithmResponse = await _api.GetLiveAlgorithmListAsync(AlgorithmStatus.Running);
            var liveAlgorithmResultsResponse = await _api.GetLiveAlgorithmResultsAsync(projectId, deployId);
            //var logsResponse = await _api.GetLiveAlgorithmLogs(projectId, deployId);
            //var projectsResponse = await _api.GetProjectsAsync();
            //var projectResponse = await _api.GetProjectAsync(projectId).ConfigureAwait(false);

            var result = new AlgorithmResult();
            var parser = new ApiResultParser();
            parser.ProcessLiveResult(result, liveAlgorithmResultsResponse);

            var firstItem = result.EquityChart.First().X;
            var lastItem = result.EquityChart.Last().X;
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
