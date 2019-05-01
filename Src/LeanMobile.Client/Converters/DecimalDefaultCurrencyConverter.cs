using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace LeanMobile.Client.Converters
{
    public class QuantityConverter : IValueConverter
    {
        private const string FormatString = "0,0;- 0,0"; // Has special formatting for negative

        // TODO: Use a static provider to set the global default culture
        public static readonly CultureInfo CultureInfo = new CultureInfo("en-US");

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return decimal.Parse(value.ToString()).ToString(FormatString, CultureInfo);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    public class DecimalDefaultCurrencyConverter : IValueConverter
    {
        private const string FormatString = "0,0.00;- 0,0.00"; // Has special formatting for negative
        private const decimal FallbackValue = 0m;

        // TODO: Use a static provider to set the global default culture
        public static readonly CultureInfo CultureInfo = new CultureInfo("en-US");

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return decimal.Parse(value.ToString()).ToString(FormatString, CultureInfo);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
