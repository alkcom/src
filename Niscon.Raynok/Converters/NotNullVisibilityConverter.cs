using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Niscon.Raynok.Converters
{
    public class NotNullVisibilityConverter : IValueConverter
    {
        public bool Inverted { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Inverted
                ? value == null
                    ? Visibility.Visible
                    : Visibility.Collapsed
                : value != null
                    ? Visibility.Visible
                    : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
