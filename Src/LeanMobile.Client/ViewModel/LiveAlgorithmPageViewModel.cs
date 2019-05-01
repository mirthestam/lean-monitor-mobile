using System;
using System.Reactive.Linq;
using LeanMobile.Algorithms;
using LeanMobile.Client.View.LiveAlgorithm;
using LeanMobile.Client.ViewModel.LiveAlgorithm.Dashboard;
using LeanMobile.Client.ViewModel.LiveAlgorithm.Orders;
using Prism.Navigation;

namespace LeanMobile.Client.ViewModel
{
    public class LiveAlgorithmPageViewModel : PageViewModelBase
    {
        private readonly IAlgorithmService _algorithmService;

        private AlgorithmId _algorithmId;

        public DashboardViewViewModel Dashboard { get; set; }

        public OrdersViewViewModel Orders { get; set; }

        public decimal Equity { get; set; }
        public decimal Unrealized { get; set; }
        public decimal Holdings { get; set; }

        public string Name { get; set; }

        public LiveAlgorithmPageViewModel(IAlgorithmService algorithmService)
        {
            _algorithmService = algorithmService;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            switch (parameters.GetNavigationMode())
            {
                case NavigationMode.Back:
                    break;

                case NavigationMode.New:

                    _algorithmId = parameters.GetValue<AlgorithmId>(LiveAlgorithmPage.Parameters.Id);

                    RefreshAlgorithm();

                    // Subscrive to updates for this algorithm
                    Subscribe();

                    break;

                default:
                    throw new ArgumentException($"Unsupported NavigationMode: {parameters.GetNavigationMode()}",
                                                nameof(parameters));
            }
        }

        public override void OnSleep()
        {
            Unsubscribe();
        }

        public override void OnResume()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            // TODO: Subscribe to this algorithm
            _algorithmService.Subscribe(_algorithmId, ResultSubscriptionType.LiveResults | ResultSubscriptionType.Log);
        }

        private void Unsubscribe()
        {
            _algorithmService.ClearSubscriptions();
        }

        private void RefreshAlgorithm()
        {
            // Create the view models
            var algorithmResultsObservable = _algorithmService.AlgorithmResults.Where(a => a.AlgorithmId == _algorithmId);
            Dashboard = new DashboardViewViewModel(algorithmResultsObservable);
            Orders = new OrdersViewViewModel(algorithmResultsObservable);


            algorithmResultsObservable.Select(result => result.Statistics).Subscribe(statistics =>
            {
                if (statistics == null) return;
                Equity = statistics.Equity;
                Unrealized = statistics.Unrealized;
                Holdings = statistics.Holdings;
            });

            // Get the algorithm information
            _algorithmService
                .GetAlgorithm(_algorithmId)
                .Subscribe(algorithm => Name = algorithm.Name);
        }
    }
}