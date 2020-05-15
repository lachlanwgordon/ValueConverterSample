using System;
using System.Globalization;
using ValueConverterSample.Converters;
using Xamarin.Forms;


namespace ValueConverterSample.Converters
{
    [ValueConversion(typeof(double), typeof(bool))]
    public class DoubleToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double == false)
            {
                return default(bool);
            }

            var input = (double)value;

            if(double.TryParse((string) parameter, out double threshold))
            {
                return input > threshold;
            }
            return input > 20;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool == false)
            {
                return default(double);
            }

            var input = (bool)value;
            if (double.TryParse((string)parameter, out double threshold))
            {
                return input ? threshold + 5 : threshold - 5;
            }
            return input ? 25 : 15;
        }
    }
}