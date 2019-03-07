using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using LeanMobile.Client;
using LeanMobile.Settings;

namespace LeanMobile.Droid
{
    [Activity(Label = "LeanMobile", Icon = "@mipmap/icon", Theme = "@style/MainTheme.Light", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
           
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::CarouselView.FormsPlugin.Android.CarouselViewRenderer.Init();

            SetTheme();

            var platformInitializer = new Initializer();
            LoadApplication(new App(platformInitializer));
        }

        private void SetTheme()
        {
            int themeId;
            switch (AppSettings.Current.Theme)
            {
                case AppTheme.Dark:
                    themeId = Resource.Style.MainTheme_Dark;
                    break;

                case AppTheme.Light:
                    themeId = Resource.Style.MainTheme_Light;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            SetTheme(themeId);
        }
    }
}