using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using LeanMobile.Algorithms;
using LeanMobile.Client.View.LiveAlgorithm;
using Prism.Navigation;

namespace LeanMobile.Client.ViewModel
{
    public class LiveAlgorithmPageViewModel : PageViewModelBase
    {        
        private readonly IAlgorithmService _algorithmService;

        private IDisposable _algorithmResultSubscription;

        public decimal Equity { get; set; } = 103400;
        public decimal Unrealized { get; set; } = -344.23m;
        public decimal Holdings { get; set; } = 34.34m;

        public string Name { get; set; }

        public LiveAlgorithmPageViewModel(IAlgorithmService algorithmService)
        {
            _algorithmService = algorithmService;
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            switch (parameters.GetNavigationMode())
            {
                case NavigationMode.Back:
                    break;
                case NavigationMode.New:
                    var algorithmId = parameters.GetValue<string>(LiveAlgorithmPage.Parameters.Id);
                    RefreshAlgorithm(algorithmId);
                    break;
                default:
                    throw new ArgumentException($"Unsupported NavigationMode: {parameters.GetNavigationMode()}", nameof(parameters));
            }
        }

        private void RefreshAlgorithm(string algorithmId)
        {
            _algorithmService.GetAlgorithm(algorithmId).Subscribe(algorithm =>
            {
                Name = algorithm.Name;
            });
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