using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Niscon.Raynok.Converters
{
    public class EqualParameterVisibilityConverter : IValueConverter
    {
        public bool Reverse { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return /*value is string && parameter is string && */((!Reverse && value.Equals(parameter)) || (Reverse && !value.Equals(parameter)))
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility? visibility = value as Visibility?;
            string str = parameter as string;
            return (visibility.HasValue && !string.IsNullOrEmpty(str) && visibility.Value == Visibility.Visible)
                ? str
                : null;
        }
    }
}
