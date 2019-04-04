using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using LeanMobile.Client.Extensions;
using Xamarin.Forms;

namespace LeanMobile.Client.Converters
{
    public class IsNotNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    public class DecimalColorConverter : IValueConverter
    {
        public string TextColorKey { get; set; } = "TextColor";
        public string GreenColorKey { get; set; } = "LabelNumberGreenColor";
        public string RedColorKey { get; set; } = "LabelNumberRedColor";

        public bool UseGreen { get; set; }
        public bool UseRed { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is decimal amount)) return GreenColor;
            return ConvertDecimal(amount);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        private Color ConvertDecimal(decimal amount)
        {
            if (amount == 0)
            {
                return TextColor;
            }

            return amount < 0 ? RedColor : GreenColor;
        }

        private Color TextColor => GetColor(TextColorKey);
        private Color GreenColor => UseGreen ? GetColor(GreenColorKey) : GetColor(TextColorKey);
        private Color RedColor => UseRed ? GetColor(RedColorKey) : GetColor(TextColorKey);

        private static Color GetColor(string key)
        {
            if (!Application.Current.Resources.TryGetValue(key, out var value))
                return Color.White;

            if (value is OnTheme<Color> theme)
                return theme.Current;

            return (Color)value;
        }
    }
}
