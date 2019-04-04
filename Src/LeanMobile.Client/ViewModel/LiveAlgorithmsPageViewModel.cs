using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using LeanMobile.Algorithms;
using LeanMobile.Client.View.LiveAlgorithm;
using Prism.Navigation;
using Xamarin.Forms;

namespace LeanMobile.Client.ViewModel
{
    public class LiveAlgorithmsPageViewModel : PageViewModelBase
    {
        private readonly IAlgorithmService _algorithmService;
        private readonly INavigationService _navigationService;

        public ObservableCollection<AlgorithmViewModel> Algorithms { get; set; } = new ObservableCollection<AlgorithmViewModel>();

        public ICommand RefreshAlgorithmsCommand { get; set; }
        public ICommand AlgorithmTappedCommand { get; set; }

        public bool IsRefreshing { get; set; }

        public LiveAlgorithmsPageViewModel(IAlgorithmService algorithmService, INavigationService navigationService)
        {
            _algorithmService = algorithmService;
            _navigationService = navigationService;

            RefreshAlgorithmsCommand = new Command(RefreshAlgorithms);
            AlgorithmTappedCommand = new Command<AlgorithmViewModel>(async (algorithm) => await NavigateToAlgorithmAsync(algorithm.Id));
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            RefreshAlgorithms();
        }

        public override void OnResume()
        {
            RefreshAlgorithms();
        }

        private async Task NavigateToAlgorithmAsync(string id)
        {
            await _navigationService.NavigateAsync($"{nameof(LiveAlgorithmPage)}?{LiveAlgorithmPage.Parameters.Id}={id}");
        }

        private void RefreshAlgorithms()
        {            
            _algorithmService.GetAlgorithms().Subscribe(algorithms =>
            {
                    // Algorithm service might invoke multiple times.
                    // First, it will fire for the cached data.
                    // Second, it might fire with updated data retrieved from remote.
                    algorithms = algorithms.OrderBy(a => a.Name);

                    IsRefreshing = true;

                    try
                    {
                        Algorithms.Clear();

                        foreach (var algorithm in algorithms)
                        {
                            var algorithmViewModel = new AlgorithmViewModel(algorithm);
                            Algorithms.Add(algorithmViewModel);
                        }
                    }
                    finally
                    {
                        IsRefreshing = false;
                    }
            });
        }
    }
}
