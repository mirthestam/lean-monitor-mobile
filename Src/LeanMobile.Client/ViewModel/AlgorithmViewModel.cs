using LeanMobile.Algorithms;
using LeanMobile.Algorithms.Results;
using System;

namespace LeanMobile.Client.ViewModel
{
    public class AlgorithmViewModel
    {
        private readonly Algorithm _algorithm;

        public AlgorithmViewModel(Algorithm algorithm, IObservable<AlgorithmResult> algorithmResults)
        {
            _algorithm = algorithm;
            //algorithmResults.Subscribe()
        }

        public AlgorithmId Id => _algorithm.Id;
        public string Name => _algorithm.Name;

        // TODO: Handle data
        public decimal Unrealized { get; set; }
        public decimal Equity { get; set; }
        public decimal Holdings { get; set; }
    }
}