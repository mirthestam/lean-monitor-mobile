using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace LeanMobile.Client.Utils
{
    public class DebugValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Debug.WriteLine(string.Format(culture, "Convert: Value={0}, TargetType={1}, Parameter={2}, Culture={3}",value, targetType, parameter, culture));
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Debug.WriteLine(string.Format(culture, "ConvertBack: Value={0}, TargetType={1}, Parameter={2}, Culture={3}", value, targetType, parameter, culture));
            return value;
        }
    }
}
