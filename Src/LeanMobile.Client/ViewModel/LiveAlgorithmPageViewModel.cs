using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using LeanMobile.Algorithms;
using LeanMobile.Client.View.LiveAlgorithm;
using LeanMobile.Client.ViewModel.LiveAlgorithm.Dashboard;
using Prism.Navigation;

namespace LeanMobile.Client.ViewModel
{
    public class LiveAlgorithmPageViewModel : PageViewModelBase
    {        
        private readonly IAlgorithmService _algorithmService;

        public DashboardViewViewModel Dashboard { get; set; }

        private IDisposable _algorithmResultSubscription;

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

                    var algorithmId = parameters.GetValue<string>(LiveAlgorithmPage.Parameters.Id);

                    // Create the view models
                    var algorithmResultsObservable = _algorithmService.AlgorithmResults.Where(a => a.AlgorithmId == algorithmId);
                    
                    algorithmResultsObservable.Select(result => result.Statistics).Subscribe(statistics =>
                    {
                        if (statistics == null) return;                             
                            Equity = statistics.Equity;
                            Unrealized = statistics.Unrealized;
                            Holdings = statistics.Holdings;
                        });

                    Dashboard = new DashboardViewViewModel(algorithmResultsObservable);

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
    }
}