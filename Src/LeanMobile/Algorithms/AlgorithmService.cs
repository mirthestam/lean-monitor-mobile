using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using Akavache;
using LeanMobile.Algorithms.Results;

namespace LeanMobile.Algorithms
{
    public class AlgorithmService : IAlgorithmService
    {
        private readonly IAlgorithmRepository _algorithmRepository;
        private readonly IAlgorithmResultProvider _algorithmResultProvider;
        private readonly IObjectBlobCache _cache;

        public IObservable<AlgorithmResult> AlgorithmResults { get; private set; }

        public AlgorithmService(IAlgorithmRepository algorithmRepository, IAlgorithmResultProvider algorithmResultProvider, IObjectBlobCache cache)
        {
            _algorithmRepository = algorithmRepository;
            _algorithmResultProvider = algorithmResultProvider;
            _cache = cache;

            _algorithmResultProvider.Run();

            CreateResultObservable();
        }

        public IObservable<IEnumerable<Algorithm>> GetAlgorithms()
        {
            // Get the old version from cache. Simultaneously fetch the latest list from the API when the cached data is to old.
            return _cache.GetAndFetchLatest("Algorithms", async () => await _algorithmRepository.GetAlgorithmsAsync().ConfigureAwait(false),
                offset =>
                {
                    var elapsed = DateTimeOffset.Now - offset;
                    return elapsed.TotalSeconds > 10;
                });
        }

        public IObservable<Algorithm> GetAlgorithm(AlgorithmId algorithmId) => GetAlgorithms().Select(algorithms => algorithms.First(a => a.Id == algorithmId));

        private void CreateResultObservable()
        {
            // Create observable for the event
            var observable = Observable.FromEventPattern<AlgorithmResultEventArgs>(
                handler => _algorithmResultProvider.AlgorithmResultReceived += handler,
                handler => _algorithmResultProvider.AlgorithmResultReceived -= handler);

            // Create observable for the inner data
            AlgorithmResults = observable.Select(e => e.EventArgs.Result);
        }

        public void Subscribe(AlgorithmId algorithmId, ResultSubscriptionType resultSubscriptionType) => _algorithmResultProvider.Subscribe(algorithmId, resultSubscriptionType);

        public void UnsubscribeAll() => _algorithmResultProvider.ClearSubscriptions();
    }
}
