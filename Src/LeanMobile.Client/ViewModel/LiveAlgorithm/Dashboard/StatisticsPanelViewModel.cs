using System;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using LeanMobile.Algorithms;
using LeanMobile.Algorithms.Results;
using Prism.Mvvm;

namespace LeanMobile.Client.ViewModel.LiveAlgorithm.Dashboard
{
    public class StatisticsPanelViewModel : BindableBase
    {
        public decimal Fees { get; set; } = 0;

        public decimal NetProfit { get; set; } = 0;

        public decimal Return { get; set; } = 0;

        public StatisticsPanelViewModel(IObservable<AlgorithmResult> algorithmResults)
        {
            Fees = 340;
            algorithmResults.Select(r => r.Statistics).Subscribe(statistics =>
            {
                if (statistics == null) return;

                Fees = statistics.Fees;
                NetProfit = statistics.NetProfit;
                Return = statistics.ReturnPercentage;
            });
        }
    }
}


