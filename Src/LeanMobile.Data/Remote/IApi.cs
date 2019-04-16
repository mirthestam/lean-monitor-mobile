using System.Threading.Tasks;
using LeanMobile.Data.Remote.Responses;
using Refit;

namespace LeanMobile.Data.Remote
{
    public interface IApi
    {
        [Get("/authenticate")]
        Task<AuthenticationResponse> GetAuthenticateAsync();

        [Get("/live/read")] // TODO: implement query string parameters DateTime start, DateTime end
        Task<LiveListResponse> GetLiveAlgorithmListAsync([AliasAs("status")]AlgorithmStatus algorithmStatus);// Original method is ListLiveAlgorithms        

        [Get("/live/read")]
        Task<LiveAlgorithmResultsResponse> GetLiveAlgorithmResultsAsync([AliasAs("projectId")]int projectId, [AliasAs("deployId")]string deployId); // Original method is ReadLiveAlgorithm

        [Get("/live/read/log")] // TODO: implement query string parameters DateTime start, DateTime end
        Task<LiveLogResponse> GetLiveAlgorithmLogs([AliasAs("projectId")]int projectId, [AliasAs("algorithmId")]string deployId); // Original method ReadLiveLogs

        [Post("/live/update/liquidate")] // TODO: Implement query string parameter ProjectId
        Task<Response> PostLiquidateLiveAlgorithmAsync(); // Original method LiquidateLiveAlgorithm

        [Post("/live/update/stop")] // TODO: Implement query string parameter projectId
        Task<Response> PostStopLiveAlgorithmAsync(); // Original method: StopLiveAlgorithm

        [Get("/projects/read")]
        Task<ProjectListResponse> GetProjectsAsync(); // Original method: ListProjects

        [Get("/projects/read")]
        Task<ProjectListResponse> GetProjectAsync([AliasAs("projectId")]int projectId); // Original method: ReadProject
    }
}