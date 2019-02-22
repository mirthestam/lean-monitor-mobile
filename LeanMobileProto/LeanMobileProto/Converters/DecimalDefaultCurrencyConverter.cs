using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace LeanMobileProto.Converters
{
    public class DecimalDefaultCurrencyConverter : IValueConverter
    {
        private const string FormatString = "0,0.00;- 0,0.00"; // Has special formatting for negative
        private const decimal FallbackValue = 0m;

        // TODO: Use a static provider to set the global default culture
        public static readonly CultureInfo CultureInfo = new CultureInfo("en-US");

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Convert to a string
            return decimal.Parse(value.ToString()).ToString(FormatString, CultureInfo);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
