using System;
using LeanMobileProto.Model.Api;
using LeanMobileProto.Services.Api;
using LeanMobileProto.Services.Authentication;
using LeanMobileProto.Services.Settings;
using LeanMobileProto.View;
using LeanMobileProto.ViewModel;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LeanMobileProto
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer platformInitializer) : base(platformInitializer) { }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Services
            containerRegistry.Register<IApiFactory, ApiFactory>();
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterSingleton<ISettingsService, SettingsService>();
            containerRegistry.Register<IAuthenticationService, AuthenticationService>();

            // Views
            containerRegistry.RegisterForNavigation<NavigationPage>();        
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<MainPage>();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }
    }
}
