using System.Threading.Tasks;
using LeanMobile.Api.Responses;
using Refit;

namespace LeanMobile.Api
{
    public interface IApi
    {
        [Get("/authenticate")]
        Task<AuthenticationResponse> GetAuthenticateAsync();

        [Get("/live/read")] // TODO: Implement query string parameters Status, DateTimeStart, dateTimeEnd
        Task<LiveListResponse> GetLiveAlgorithmListAsync();// Original method is ListLiveAlgorithms        

        [Get("/live/read")] // TODO: Implement query string parameters projectId, deployId
        Task<LiveAlgorithmResultsResponse> GetLiveAlgorithmResultsAsync(); // Original method is ReadLiveAlgorithm

        [Get("/live/read/log")] // TODO: implement query string parameters projectId, algorithmId, DateTime start, DateTime end
        Task<LiveLogResponse> GetLiveAlgorithmLogs(); // Original method ReadLiveLogs

        [Post("/live/update/liquidate")] // TODO: Implement query string parameter ProjectId
        Task<Response> PostLiquidateLiveAlgorithmAsync(); // Original method LiquidateLiveAlgorithm

        [Post("/live/update/stop")] // TODO: Implement query string parameter projectId
        Task<Response> PostStopLiveAlgorithmAsync(); // Original method: StopLiveAlgorithm
    }
}