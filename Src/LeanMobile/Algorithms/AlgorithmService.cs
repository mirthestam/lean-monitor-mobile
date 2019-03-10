using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace LeanMobile.Algorithms
{
    public class AlgorithmService : IAlgorithmService
    {
        private readonly IAlgorithmRepository _algorithmRepository;
        private readonly IAlgorithmResultProvider _statisticProvider;

        public IObservable<AlgorithmResult> AlgorithmResults { get; private set; }

        public AlgorithmService(IAlgorithmRepository algorithmRepository, IAlgorithmResultProvider statisticProvider)
        {
            _algorithmRepository = algorithmRepository;
            _statisticProvider = statisticProvider;

            CreateResultObservable();
        }

        public Task<IEnumerable<Algorithm>> GetAlgorithmsAsync()
        {
            return _algorithmRepository.GetAlgorithmsAsync();
        }

        private void CreateResultObservable()
        {
            // Create observable for the event
            var observable = Observable.FromEventPattern<AlgorithmResultEventArgs>(
                handler => _statisticProvider.AlgorithmResultReceived += handler,
                handler => _statisticProvider.AlgorithmResultReceived -= handler);

            // Create observable for the inner data
            AlgorithmResults = observable.Select(e => e.EventArgs.Result);
        }        

    }
}
