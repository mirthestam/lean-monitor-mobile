using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LeanMobile.Algorithms;
using LeanMobile.Client.View.LiveAlgorithm;
using LeanMobile.Utils;
using Prism.Navigation;
using Xamarin.Forms;

namespace LeanMobile.Client.ViewModel
{
    public class LiveAlgorithmsPageViewModel  : PageViewModelBase
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

            RefreshAlgorithmsCommand = new Command(async() => await RefreshAlgorithmsAsync());
            AlgorithmTappedCommand = new Command<AlgorithmViewModel>(async (algorithm) => await NavigateToAlgorithmAsync(algorithm.Id));
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            await RefreshAlgorithmsAsync();
        }

        private async Task NavigateToAlgorithmAsync(string id)
        {
            await _navigationService.NavigateAsync($"{nameof(LiveAlgorithmPage)}?{LiveAlgorithmPage.Parameters.Id}={id}");
        }

        private async Task RefreshAlgorithmsAsync()
        {
            try
            {
                IsRefreshing = true;

                Algorithms.Clear();
                var algorithms = await _algorithmService.GetAlgorithmsAsync();
                algorithms = algorithms.OrderBy(a => a.Name);

                foreach (var algorithm in algorithms)
                {
                    var algorithmViewModel = new AlgorithmViewModel(algorithm);
                    Algorithms.Add(algorithmViewModel);
                }
            }
            catch
            {
                Algorithms.Clear();
            }
            finally
            {
                IsRefreshing = false;
            }
        }
    }
}
