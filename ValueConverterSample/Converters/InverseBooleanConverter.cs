using System;
using System.Globalization;
using ValueConverterSample.Converters;
using Xamarin.Forms;


namespace ValueConverterSample.Converters
{
    [ValueConversion(typeof(bool), typeof(bool))]
    public class InverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool == false)
            {
                return default(bool);
            }

            var input = (bool)value;
            return !input;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool == false)
            {
                return default(bool);
            }

            var input = (bool)value;
            return !input;
        }
    }
}