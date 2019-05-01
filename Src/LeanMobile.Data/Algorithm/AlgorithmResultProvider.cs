using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Akavache;
using LeanMobile.Algorithms;
using LeanMobile.Algorithms.Results;
using LeanMobile.Settings;

namespace LeanMobile.Data.Algorithm
{
    public class AlgorithmResultProvider : AlgorithmResultProviderBase
    {
        // AlgorithmResultProvider that implements polling to fetch updates from the API

        private static readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
       
        private readonly IApiResultParser _apiResultParser = new ApiResultParser();

        private readonly IApiService _apiService;
        private readonly ISettingsService _settingsService;

        public AlgorithmResultProvider(IApiService apiService, ISettingsService settingsService)
        {
            _apiService = apiService;
            _settingsService = settingsService;
        }

        public override void Run()
        {
            Task.Run(async () => await Poll().ConfigureAwait(false));
        }

        public override void Abort()
        {
            _cancellationTokenSource?.Cancel();
        }

        private async Task Poll()
        {
            var interval = _settingsService.PollingIntervalInMilliSeconds;

            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                foreach (var subscription in _subscriptions.ToList())
                {
                    try
                    {
                        await PollAlgorithm(subscription.Key, subscription.Value);
                    }
                    catch
                    {
                        // TODO: Write log
                        // For now, just continue and ignore this subscription
                    }
                }

                await Task.Delay(interval, _cancellationTokenSource.Token);
            }
        }

        private async Task PollAlgorithm(AlgorithmId algorithmId, ResultSubscriptionType subscription)
        {
            if (subscription == 0) throw new ArgumentOutOfRangeException(nameof(subscription), "No data has been subscribed");

            var result = new AlgorithmResult
            {
                AlgorithmId = algorithmId,
                TimeStamp = DateTime.UtcNow
            };

            if ((subscription & ResultSubscriptionType.LiveResults) != 0)
            {
                try
                {
                    var remoteLiveAlgorithmResults = await _apiService.Api.GetLiveAlgorithmResultsAsync(algorithmId.ProjectId, algorithmId.DeployId);
                    _apiResultParser.ProcessLiveResult(result, remoteLiveAlgorithmResults);
                }
                catch(Exception ex)
                {
                    // TODO: Log
                }
            }

            if ((subscription & ResultSubscriptionType.Log) != 0)
            {
                try
                {
                    // var logResults = await _apiService.Api.GetLiveAlgorithmLogs(algorithmId.ProjectId, algorithmId.DeployId);
                    // _apiResultParser.ProcessLogResult(result, logResults);
                }
                catch
                {
                    // TODO: Log
                }
            }

            // Fire the result event
            OnAlgorithmResultUpdated(new AlgorithmResultEventArgs(result));
        }
    }
}
