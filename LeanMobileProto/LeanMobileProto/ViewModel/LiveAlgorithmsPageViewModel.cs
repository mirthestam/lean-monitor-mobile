using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LeanMobileProto.ViewModel
{
    public class LiveAlgorithmsPageViewModel
    {
        public ObservableCollection<AlgorithmViewModel> Algorithms { get; set; }

        public LiveAlgorithmsPageViewModel()
        {
            Algorithms = new ObservableCollection<AlgorithmViewModel>(new List<AlgorithmViewModel>
            {
                new AlgorithmViewModel
                {
                    Title = "Sell in May",
                    Unrealized = -344.23m,
                    Equity = 103400,
                    Holdings = 34.34m
                },
                new AlgorithmViewModel
                {
                    Title = "Just buy",
                    Unrealized = 0,
                    Equity = 102300,
                    Holdings = 0
                },
                new AlgorithmViewModel
                {
                    Title = "Sell in April",
                    Unrealized = 340,
                    Equity = -103400,
                    Holdings = -340
                }
            });
        }
    }
}
