using System;
using LeanMobile.Client.ViewModel;
using Xam.Plugin.TabView;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace LeanMobile.Client.View.LiveAlgorithm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LiveAlgorithmPage : TabbedPage
    {
        public class Parameters
        {
            public const string Id = "id";
        }

        public LiveAlgorithmPage()
        {
            InitializeComponent();
        }        
    }
}