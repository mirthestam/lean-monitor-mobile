using System;
using LeanMobile.Algorithms;
using LeanMobile.Authentication;
using LeanMobile.Client.View;
using LeanMobile.Client.ViewModel;
using LeanMobile.Client.Services;
using LeanMobile.Data;
using LeanMobile.Data.Authentication;
using LeanMobile.Data.Remote.Factory;
using LeanMobile.Settings;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LeanMobile.Client
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer platformInitializer) : base(platformInitializer) { }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Services
            containerRegistry.RegisterSingleton<ISettingsService, SettingsService>();
            containerRegistry.Register<IAuthenticationService, AuthenticationService>();
            containerRegistry.RegisterSingleton<IAlgorithmService, AlgorithmService>();

            // Data
            containerRegistry.RegisterSingleton<IAlgorithmResultProvider, AlgorithmResultProvider>();
            containerRegistry.Register<IApiFactory, ApiFactory>();
            containerRegistry.Register<IApiService, ApiService>();

            // Views
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainNavigationPage>();
            containerRegistry.RegisterForNavigation<MenuPage, MenuPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LiveAlgorithmsPage, LiveAlgorithmsPageViewModel>();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync(nameof(NavigationPage) + "/" + nameof(LoginPage));
        }
    }
}
