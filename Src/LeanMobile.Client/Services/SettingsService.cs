using LeanMobile.Settings;
using Xamarin.Forms;

namespace LeanMobile.Client.Services
{
    public class SettingsService : ISettingsService
    {
        private const string AuthUserTokenKey = "AuthUserToken";
        private const string AuthAccessTokenKey = "AuthAccessToken";
        private const string EndpointAddressKey = "EndpointAddress";

        private const string EndpointAddressDefault = "https://www.quantconnect.com/api/v2";
       
        public string AuthUserToken
        {
            get => GetValueOrDefault<string>(AuthUserTokenKey);
            set => SetValue(AuthUserTokenKey, value);
        }

        public string AuthAccessToken
        {
            get => GetValueOrDefault<string>(AuthAccessTokenKey);
            set => SetValue(AuthAccessTokenKey, value);
        }

        public string EndpointAddress
        {
            get => GetValueOrDefault(EndpointAddressKey, EndpointAddressDefault);
            set => SetValue(EndpointAddressKey, value);
        }

        private static T GetValueOrDefault<T>(string key, T defaultValue = default(T))
        {
            if (!Application.Current.Properties.TryGetValue(key, out var value))
            {
                value = defaultValue;
            }

            return (T)value;
        }

        private static async void SetValue(string key, object value)
        {            
            Application.Current.Properties[key] = value;
            await Application.Current.SavePropertiesAsync();
        }
    }
}
