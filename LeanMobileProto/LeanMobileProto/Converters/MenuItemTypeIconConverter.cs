using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using LeanMobileProto.Enums;
using LeanMobileProto.Model;
using Xamarin.Forms;

namespace LeanMobileProto.Converters
{
    public class MenuItemTypeIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var menuItemType = (MenuItemType) value;

            switch (menuItemType)
            {
                case MenuItemType.Live:
                    return $"baseline_flash_on_24_{Theme}.png";
                    
                case MenuItemType.Projects:
                    return $"baseline_folder_24_{Theme}.png";

                case MenuItemType.Help:
                    return $"baseline_help_24_{Theme}.png";

                case MenuItemType.Settings:
                    return $"baseline_settings_24_{Theme}.png";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static string Theme
        {
            get
            {
                switch (AppSettings.Current.Theme)
                {
                    case AppTheme.Dark:
                        return "dark";
                        
                    case AppTheme.Light:
                        return "light";

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;        
    }
}
