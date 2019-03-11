using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using LeanMobile.Algorithms;
using LeanMobile.Utils;
using Prism.Navigation;

namespace LeanMobile.Client.ViewModel
{
    public class LiveAlgorithmsPageViewModel  : PageViewModelBase
    {
        private readonly IAlgorithmService _algorithmService;
        private readonly INavigationService _navigationService;

        public ObservableCollection<AlgorithmViewModel> Algorithms { get; set; } = new ObservableCollection<AlgorithmViewModel>();

        public LiveAlgorithmsPageViewModel(IAlgorithmService algorithmService, INavigationService navigationService)
        {
            _algorithmService = algorithmService;
            _navigationService = navigationService;
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            Algorithms.Clear();
            var algorithms = await _algorithmService.GetAlgorithmsAsync();
            foreach (var algorithm in algorithms)
            {
                var algorithmViewModel = new AlgorithmViewModel(algorithm);
                Algorithms.Add(algorithmViewModel);
            }
        }
    }
}
