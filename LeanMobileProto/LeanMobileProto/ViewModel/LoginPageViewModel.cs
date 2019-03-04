using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LeanMobileProto.Services.Settings;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace LeanMobileProto.ViewModel
{
    public class LoginPageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly ISettingsService _settingsService;

        public string AccessToken { get; set; }

        public string UserToken { get; set; }

        public ICommand LoginCommand { get; set; }

        public LoginPageViewModel(INavigationService navigationService, ISettingsService settingsService)
        {
            _navigationService = navigationService;
            _settingsService = settingsService;

            LoginCommand = new Command(async () => await LoginAsync());
        }

        private async Task LoginAsync()
        {
            _settingsService.AuthAccessToken = AccessToken;
            _settingsService.AuthUserToken = UserToken;
            await _navigationService.NavigateAsync("/MainPage");
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {            
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            if (!string.IsNullOrEmpty(_settingsService.AuthUserToken))
            {
                await LoginAsync();
            }

            AccessToken = _settingsService.AuthAccessToken;
            UserToken = _settingsService.AuthUserToken;
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }
    }
}
