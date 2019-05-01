using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeanMobile.Algorithms;
using LeanMobile.Data.Model;
using LeanMobile.Data.Utils;
using AlgorithmStatus = LeanMobile.Data.Model.AlgorithmStatus;

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

            var remoteAlgorithmResponse = await _apiService.Api.GetLiveAlgorithmListAsync(AlgorithmStatus.Running);
            var remoteProjectResponse = await _apiService.Api.GetProjectsAsync();

            remoteAlgorithmResponse.EnsureSuccess();
            remoteProjectResponse.EnsureSuccess();

            foreach (var remoteAlgorithm in remoteAlgorithmResponse.Algorithms)
            {
                var project = remoteProjectResponse.Projects.Find(p => p.ProjectId == remoteAlgorithm.ProjectId);

                var algorithm = new Algorithms.Algorithm
                {
                    Id = new AlgorithmId
                    {
                        DeployId = remoteAlgorithm.DeployId,
                        ProjectId = remoteAlgorithm.ProjectId
                    },
                    LaunchedDateTime = remoteAlgorithm.Launched,
                    Name = project.Name
                };

                switch (remoteAlgorithm.Status)
                {
                    case AlgorithmStatus.Completed:
                        algorithm.Status = Algorithms.AlgorithmStatus.Completed;
                        break;

                    case AlgorithmStatus.Running:
                        algorithm.Status = Algorithms.AlgorithmStatus.Running;
                        break;

                    case AlgorithmStatus.Liquidated:
                        algorithm.Status = Algorithms.AlgorithmStatus.Liquidated;
                        break;

                    case AlgorithmStatus.Stopped:
                        algorithm.Status = Algorithms.AlgorithmStatus.Stopped;
                        break;

                    default:
                        throw new Exception("Unexpected algorithm status");
                }

                algorithms.Add(algorithm);
            }

            return algorithms;
        }

        public async Task<Algorithms.Algorithm> GetAlgorithmAsync(string algorithmId)
        {
            var algorithms = await GetAlgorithmsAsync();
            return algorithms.First(a => a.Id.DeployId == algorithmId);
        }
    }
}