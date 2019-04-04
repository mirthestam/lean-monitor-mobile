using System;
using LeanMobile.Algorithms.Results;
using Prism.Mvvm;

namespace LeanMobile.Client.ViewModel.LiveAlgorithm.Dashboard
{
    public class DashboardViewViewModel : BindableBase
    {
        public ServerStatisticsPanelViewModel ServerStatistics { get; set; }

        public StatisticsPanelViewModel Statistics { get; set; }

        public OpenOrdersPanelViewModel OpenOrders { get; set;}

        public MarketPanelViewModel Market { get; set;}

        public LastOrdersPanelViewModel LastOrders { get; set;}

        public DashboardViewViewModel(IObservable<AlgorithmResult> algorithmResults)
        {
            ServerStatistics = new ServerStatisticsPanelViewModel(algorithmResults);
            Statistics = new StatisticsPanelViewModel(algorithmResults);
            OpenOrders = new OpenOrdersPanelViewModel(algorithmResults);
            Market = new MarketPanelViewModel(algorithmResults);
            LastOrders = new LastOrdersPanelViewModel(algorithmResults);
        }
    }
}