using System;
using System.Reactive.Linq;
using LeanMobile.Algorithms;

namespace LeanMobile.Client.ViewModel
{
    public class LiveAlgorithmPageViewModel : PageViewModelBase
    {
        private readonly IAlgorithmService _algorithmService;

        private IDisposable _algorithmResultSubscription;

        public decimal Equity { get; set; } = 103400;
        public decimal Unrealized { get; set; } = -344.23m;
        public decimal Holdings { get; set; } = 34.34m;

        public LiveAlgorithmPageViewModel(IAlgorithmService algorithmService)
        {
            _algorithmService = algorithmService;
        }

        private void SubscribeToUpdates()
        {
            // Pseudo code of how to get updates and update viewModel
            _algorithmResultSubscription = _algorithmService.AlgorithmResults
                .Where(update => update.AlgorithmId == 3)
                .Subscribe(); // TODO: Do something with the subscription
        }
    }
}