using System;
using System.Globalization;
using Xamarin.Forms;

namespace LeanMobile.Client.Utils
{
    public class NameOfConverter : IValueConverter
    {
        // Usage: <Label Text="{Binding Converter={StaticResource NameOfConverter}}"></Label>                        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "Null";
            var sourceType = value.GetType();
            return sourceType.FullName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}