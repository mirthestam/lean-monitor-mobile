using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LeanMobile.Algorithms;
using LeanMobile.Data.Utils;
using RemoteAlgorithmStatus = LeanMobile.Data.Remote.AlgorithmStatus;

namespace LeanMobile.Data.Algorithm
{
   public class AlgorithmRepository : IAlgorithmRepository
    {
        private readonly IApiService _apiService;

        public AlgorithmRepository(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IEnumerable<Algorithms.Algorithm>> GetAlgorithmsAsync()
        {
            var algorithms = new List<Algorithms.Algorithm>();

            var remoteAlgorithmResponse = await _apiService.Api.GetLiveAlgorithmListAsync();
            var remoteProjectResponse = await _apiService.Api.GetProjectsAsync();

            remoteAlgorithmResponse.EnsureSuccess();
            remoteProjectResponse.EnsureSuccess();

            foreach (var remoteAlgorithm in remoteAlgorithmResponse.Algorithms)
            {
                var project = remoteProjectResponse.Projects.Find(p => p.ProjectId == remoteAlgorithm.ProjectId);

                var algorithm = new Algorithms.Algorithm
                {
                    Id = remoteAlgorithm.DeployId,
                    LaunchedDateTime = remoteAlgorithm.Launched,
                    Name = project.Name
                };

                switch (remoteAlgorithm.Status)
                {
                    case RemoteAlgorithmStatus.Completed:
                        algorithm.Status = AlgorithmStatus.Completed;
                        break;

                    case RemoteAlgorithmStatus.Running:
                        algorithm.Status = AlgorithmStatus.Running;
                        break;

                    case RemoteAlgorithmStatus.Liquidated:
                        algorithm.Status = AlgorithmStatus.Liquidated;
                        break;

                    case RemoteAlgorithmStatus.Stopped:
                        algorithm.Status = AlgorithmStatus.Stopped;
                        break;

                    default:
                        throw new Exception("Unexpected algorithm status");                
                }

                algorithms.Add(algorithm);
            }

            return algorithms;
        }
    }
}