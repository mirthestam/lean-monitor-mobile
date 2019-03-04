using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LeanMobileProto.Services.Settings
{
    public class SettingsService : ISettingsService
    {
        private const string AuthUserTokenKey = "AuthUserToken";
        private const string AuthAccessTokenKey = "AuthAccessToken";
        private const string EndpointAddressKey = "EndpointAddress";
       
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
            get => GetValueOrDefault<string>(EndpointAddressKey);
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

        private async void SetValue(string key, object value)
        {
            Application.Current.Properties[key] = value;
            await Application.Current.SavePropertiesAsync();
        }
    }
}
