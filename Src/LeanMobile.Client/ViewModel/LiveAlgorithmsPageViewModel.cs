using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using LeanMobile.Algorithms;
using LeanMobile.Utils;
using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;

namespace LeanMobile.Client.ViewModel
{
    public class LiveAlgorithmsPageViewModel  : BindableBase, INavigationAware, IApplicationLifecycleAware 
    {
        private readonly IAlgorithmService _algorithmService;
        private readonly INavigationService _navigationService;

        public ObservableCollection<AlgorithmViewModel> Algorithms { get; set; } = new ObservableCollection<AlgorithmViewModel>();

        public LiveAlgorithmsPageViewModel(IAlgorithmService algorithmService, INavigationService navigationService)
        {
            _algorithmService = algorithmService;
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            // TODO: Unsubscribe from live events for all shown algorithms
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            // TODO: Refresh the list of algorithms (background if back, foreground if user initiated (to)
            // TODO: Subscribe to live updates            
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

        public void OnResume()
        {
            // TODO: Refresh the list of algorithms
            // TODO: Subscribe to live updates
        }

        public void OnSleep()
        {
            // TODO: unsubscribe to live updates
        }
    }
}
