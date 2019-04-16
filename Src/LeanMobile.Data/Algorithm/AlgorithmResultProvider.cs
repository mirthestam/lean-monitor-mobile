using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LeanMobile.Algorithms;
using LeanMobile.Algorithms.Results;
using LeanMobile.Data.Remote;
using LeanMobile.Data.Remote.Responses;
using LeanMobile.Data.Utils;
using LeanMobile.Settings;

namespace LeanMobile.Data
{
    public abstract class AlgorithmResultProvider : IAlgorithmResultProvider
    {
        protected readonly Dictionary<AlgorithmId, ResultSubscriptionType> _subscriptions = new Dictionary<AlgorithmId, ResultSubscriptionType>();

        public event EventHandler<AlgorithmResultEventArgs> AlgorithmResultReceived;

        public abstract void Run();

        public abstract void Abort();

        protected virtual void OnAlgorithmResultUpdated(AlgorithmResultEventArgs e)
        {
            AlgorithmResultReceived?.Invoke(this, e);
        }

        public void Subscribe(AlgorithmId algorithmId, ResultSubscriptionType resultSubscriptionType)
        {
            lock (_subscriptions)
            {
                if (_subscriptions.TryGetValue(algorithmId, out ResultSubscriptionType newSubscription))
                {
                    newSubscription &= resultSubscriptionType;
                }
                else
                {
                    newSubscription = resultSubscriptionType;
                }

                _subscriptions[algorithmId] = newSubscription;
            }
        }

        public void Unsubscribe(AlgorithmId algorithmId, ResultSubscriptionType resultSubscriptionType = ResultSubscriptionType.All)
        {
            lock (_subscriptions)
            {
                if (resultSubscriptionType == ResultSubscriptionType.All)
                {
                    _subscriptions.Remove(algorithmId);
                }
                else
                {
                    var subscription = _subscriptions[algorithmId];
                    subscription &= ~resultSubscriptionType;
                }
            }
        }

        public void ClearSubscriptions()
        {
            lock (_subscriptions)
            { 
                _subscriptions.Clear();
            }
        }
    }

    public class PollingAlgorithmResultProvider : AlgorithmResultProvider
    {
        private static readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        private readonly IApiService _apiService;
        private readonly ISettingsService _settingsService;

        public PollingAlgorithmResultProvider(IApiService apiService, ISettingsService settingsService)
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
                await Task.Delay(interval, _cancellationTokenSource.Token).ContinueWith(async _ =>
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
                });
            }
        }

        private async Task PollAlgorithm(AlgorithmId algorithmId, ResultSubscriptionType subscription)
        {
            if (subscription == 0) throw new ArgumentOutOfRangeException(nameof(subscription), "No data has been subscribed");

            var result = new AlgorithmResult
            {
                AlgorithmId = algorithmId
            };

            if ((subscription & ResultSubscriptionType.LiveResults) != 0)
            {
                try
                {
                    var remoteLiveAlgorithmResults = await _apiService.Api.GetLiveAlgorithmResultsAsync(algorithmId.ProjectId, algorithmId.DeployId);
                    ProcessLiveResult(result, remoteLiveAlgorithmResults);
                }
                catch
                {
                    // TODO: Log
                }
            }

            if ((subscription & ResultSubscriptionType.Log) != 0)
            {
                try
                {
                    var logResults = await _apiService.Api.GetLiveAlgorithmLogs(algorithmId.ProjectId, algorithmId.DeployId);
                    ProcessLogResult(result, logResults);
                }
                catch
                {
                    // TODO: Log
                }
            }

            // Fire the result event
            OnAlgorithmResultUpdated(new AlgorithmResultEventArgs(result));
        }

        private void ProcessLiveResult(AlgorithmResult result, LiveAlgorithmResultsResponse response)
        {
            response.EnsureSuccess();

            var serverStatistics = response.LiveResults?.Results?.ServerStatistics;
            if (serverStatistics != null)
            {
                result.ServerStatistics = new ServerStatistics();

                if (serverStatistics.TryGetValue("CpuUsage", out string statistic))
                {
                    // TODO: Parse the statistic
                    result.ServerStatistics.CpuUsage = 0;
                }

                if (serverStatistics.TryGetValue("Uptime", out statistic))
                {
                    // TODO: Parse the statistic
                    result.ServerStatistics.Uptime = new TimeSpan();
                }

                if (serverStatistics.TryGetValue("MemoryUsed", out statistic))
                {
                    // TODO: Parse the statistic
                    result.ServerStatistics.MemoryUsed = 0;
                }

                if (serverStatistics.TryGetValue("MemoryTotal", out statistic))
                {
                    // TODO: Parse the statistic
                    result.ServerStatistics.MemoryTotal = 0;
                }
            }

            // TODO: parse runtime statistics
            // TODO: Parse statistics
            // TODO: Parse Profit Loss
        }

        private void ProcessLogResult(AlgorithmResult result, LiveLogResponse response)
        {
            response.EnsureSuccess();

            result.Log = response.Logs;
        }
    }
}
