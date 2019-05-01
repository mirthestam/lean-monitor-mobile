using LeanMobile.Algorithms.Results;
using Prism.Mvvm;
using System;

namespace LeanMobile.Client.ViewModel.LiveAlgorithm.Dashboard
{
    public class MarketPanelViewModel : BindableBase
    {
        public MarketPanelViewModel(IObservable<AlgorithmResult> algorithmResults)
        {
        }
    }
}


