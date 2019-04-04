using System;
using LeanMobile.Client.ViewModel;
using Xam.Plugin.TabView;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace LeanMobile.Client.View.LiveAlgorithm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LiveAlgorithmPage : ContentPage
    {
        public class Parameters
        {
            public const string Id = "id";
        }

        public LiveAlgorithmPage()
        {
            InitializeComponent();
        }

        protected override void OnSizeAllocated(
            double dblWidth,
            double dblHeight
        )
        {
            base.OnSizeAllocated(dblWidth, dblHeight);

            // fix for carouselview orientation bug on android
            if(Device.RuntimePlatform == Device.Android)
            {
            }
        }
    }
}