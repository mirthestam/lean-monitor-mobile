using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LeanMobile.Services.Authentication;
using LeanMobile.Services.Settings;
using LeanMobile.View;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace LeanMobile.ViewModel
{
    public class LoginPageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly ISettingsService _settingsService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IPageDialogService _pageDialogService;

        public string AccessToken { get; set; }

        public string UserToken { get; set; }

        public ICommand LoginCommand { get; set; }

        public LoginPageViewModel(INavigationService navigationService, ISettingsService settingsService, IAuthenticationService authenticationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _settingsService = settingsService;
            _authenticationService = authenticationService;
            _pageDialogService = pageDialogService;

            LoginCommand = new Command(async () => await LoginAsync());
        }

        private async Task LoginAsync()
        {            
            var authenticated = await _authenticationService.IsAuthenticated(UserToken, AccessToken);

            if (authenticated)
            {
                // Store the credentials
                _settingsService.AuthAccessToken = AccessToken;
                _settingsService.AuthUserToken = UserToken;

                await _navigationService.NavigateAsync("/" + nameof(MainPage) + "/" + nameof(NavigationPage) + "/" + nameof(LiveAlgorithmsPage));
            }
            else
            {
                await _pageDialogService.DisplayAlertAsync("Authentication failed", "Invalid credentials or server unreachable.", "OK");
            }
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            AccessToken = _settingsService.AuthAccessToken;
            UserToken = _settingsService.AuthUserToken;
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }
    }
}
