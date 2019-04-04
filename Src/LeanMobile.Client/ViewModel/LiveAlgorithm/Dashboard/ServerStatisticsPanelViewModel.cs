using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using LeanMobile.Algorithms;
using LeanMobile.Algorithms.Results;
using Prism.Mvvm;

namespace LeanMobile.Client.ViewModel.LiveAlgorithm.Dashboard
{
    public class ServerStatisticsPanelViewModel : BindableBase
    {
        public int CpuUsage { get; set; } = 0;

        public int MemoryUsed { get; set; } = 0;

        public int MemoryTotal { get; set; } = 0;

        public TimeSpan Uptime { get; set; }

        public ServerStatisticsPanelViewModel(IObservable<AlgorithmResult> algorithmResults)
        {
            algorithmResults.Select(r => r.ServerStatistics).Subscribe(statistics =>
            {
                if (statistics == null) return;
                CpuUsage = statistics.CpuUsage;
                MemoryUsed = statistics.MemoryUsed;
                MemoryTotal = statistics.MemoryTotal;
                Uptime = statistics.Uptime;
            });
        }
    }
}
