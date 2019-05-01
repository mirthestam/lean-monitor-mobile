using LeanMobile.Algorithms.Results;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;

namespace LeanMobile.Client.ViewModel.LiveAlgorithm.Holdings
{
    public class HoldingsViewViewModel : BindableBase
    {
        public HoldingsViewViewModel(IObservable<AlgorithmResult> algorithmResults)
        {
            // TODO: Subscribe to holdings data updates
            //algorithmResults.Select(r => r.)
        }
    }
}
