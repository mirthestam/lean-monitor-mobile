using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Akavache;
using LeanMobile.Algorithms;
using LeanMobile.Algorithms.Results;
using LeanMobile.Settings;

namespace LeanMobile.Data.Algorithm
{
    public sealed class AlgorithmResultProvider : IAlgorithmResultProvider
    {
        private static readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        private readonly IApiResultParser _apiResultParser = new ApiResultParser();
        private readonly IApiService _apiService;
        private readonly ISettingsService _settingsService;
        private readonly IObjectBlobCache _cache;

        private readonly Dictionary<AlgorithmId, ResultSubscriptionType> _subscriptions = new Dictionary<AlgorithmId, ResultSubscriptionType>();

        public event EventHandler<AlgorithmResultEventArgs> AlgorithmResultReceived;

        public AlgorithmResultProvider(IApiService apiService, ISettingsService settingsService, IObjectBlobCache cache)
        {
            _apiService = apiService;
            _settingsService = settingsService;
            _cache = cache;
        }

        public async Task Subscribe(AlgorithmId algorithmId, ResultSubscriptionType resultSubscriptionType)
        { 
            if (_subscriptions.TryGetValue(algorithmId, out ResultSubscriptionType newSubscription))
            {
                // This is an existing subscription. Add requested data
                newSubscription &= resultSubscriptionType;
            }
            else
            {
                // This is a new subscription.
                newSubscription = resultSubscriptionType;

                // When subscribed, we expect the user wants to see data fast.
                // Therefore, we get data from cache, send it, and immediately refresh from the server
                // After subscribing, the polling mechanism will update data further.

                var result = await _cache.GetObject<AlgorithmResult>(algorithmId.DeployId);
                if (result != null)
                {
                    OnAlgorithmResultUpdated(new AlgorithmResultEventArgs(result));
                }
            }

            // Save the subscription
            _subscriptions[algorithmId] = newSubscription;
        }

        public void ClearSubscriptions()
        {
            lock (_subscriptions)
            {
                _subscriptions.Clear();
            }
        }

        public void Run()
        {
            Task.Run(async () => await Poll().ConfigureAwait(false));
        }

        private void OnAlgorithmResultUpdated(AlgorithmResultEventArgs e)
        {
            AlgorithmResultReceived?.Invoke(this, e);
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
            if (subscription == 0)
                throw new ArgumentOutOfRangeException(nameof(subscription), "No data has been subscribed");

            var result = await _cache.GetOrCreateObject(algorithmId.DeployId, () => new AlgorithmResult
            {
                AlgorithmId = algorithmId,
            });

            // Check whether we need to update live results
            if ((subscription & ResultSubscriptionType.LiveResults) != 0)
            {
                try
                {
                    var remoteLiveAlgorithmResults = await _apiService.Api.GetLiveAlgorithmResultsAsync(algorithmId.ProjectId, algorithmId.DeployId);
                    _apiResultParser.ProcessLiveResult(result, remoteLiveAlgorithmResults);
                }
                catch (Exception ex)
                {
                    // TODO: Log
                }
            }

            // Check whether we need to update the log
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

            // Cache the result
            await _cache.InsertObject(algorithmId.DeployId, result);
        }
    }
}