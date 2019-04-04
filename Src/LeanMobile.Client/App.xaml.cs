using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using Akavache;
using Akavache.Sqlite3;
using LeanMobile.Algorithms;
using LeanMobile.Algorithms.Results;
using LeanMobile.Authentication;
using LeanMobile.Client.View;
using LeanMobile.Client.ViewModel;
using LeanMobile.Client.Services;
using LeanMobile.Client.View.LiveAlgorithm;
using LeanMobile.Client.View.LiveAlgorithm.Dashboard;
using LeanMobile.Client.ViewModel.LiveAlgorithm.Dashboard;
using LeanMobile.Data;
using LeanMobile.Data.Algorithm;
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
            containerRegistry.Register<IAlgorithmRepository, AlgorithmRepository>();
            containerRegistry.RegisterSingleton<IAlgorithmResultProvider, AlgorithmResultProvider>();
            containerRegistry.Register<IApiFactory, ApiFactory>();
            containerRegistry.Register<IApiService, ApiService>();            
            containerRegistry.RegisterInstance(typeof(IObjectBlobCache), BlobCache.LocalMachine);

            // Views
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainNavigationPage>();
            containerRegistry.RegisterForNavigation<MenuPage, MenuPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LiveAlgorithmsPage, LiveAlgorithmsPageViewModel>();
            containerRegistry.RegisterForNavigation<LiveAlgorithmPage, LiveAlgorithmPageViewModel>();            
        }

        protected override void OnSleep()
        {
            base.OnSleep(); // Sleeps the viewModels

            // Flush the caches
            var caches = new[]
            {
                BlobCache.LocalMachine,
                BlobCache.Secure
            };
            // Flush method is an observable. Merge all observables and wait for them to complete.
            caches.Select(x => x.Flush())
                .Merge()
                .Select(u => Unit.Default)
                .Wait();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            Akavache.Registrations.Start("LeanMobile");

            await NavigationService.NavigateAsync(nameof(NavigationPage) + "/" + nameof(LoginPage));
        }
    }
}
