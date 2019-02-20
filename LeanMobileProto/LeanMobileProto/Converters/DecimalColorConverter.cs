using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace LeanMobileProto.Converters
{
    public class DecimalColorConverter : IValueConverter
    {
        public Color PositiveColor { get; set; }

        public Color NegativeColor { get; set; }

        public Color NeutralColor { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is decimal amount)) return PositiveColor;            
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
                return NeutralColor;
            }

            return amount < 0 ? NegativeColor : PositiveColor;
        }
    }
}
