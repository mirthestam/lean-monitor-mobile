using LeanMobile.Algorithms;
using LeanMobile.Algorithms.Results;
using Prism.Mvvm;
using System;
using System.Reactive.Linq;

namespace LeanMobile.Client.ViewModel
{
    public class AlgorithmViewModel : BindableBase
    {
        private readonly Algorithm _algorithm;

        public AlgorithmViewModel(Algorithm algorithm, IObservable<AlgorithmResult> algorithmResults)
        {
            _algorithm = algorithm;
            algorithmResults.Select(r => r.Statistics).Subscribe(r =>
            {
                if (r == null) return;

                Unrealized = r.Unrealized;
                Equity = r.Equity;
                Holdings = r.Holdings;
            });
        }

        public AlgorithmId Id => _algorithm.Id;
        public string Name => _algorithm.Name;

        // TODO: Handle data
        public decimal Unrealized { get; set; }
        public decimal Equity { get; set; }
        public decimal Holdings { get; set; }
    }
}