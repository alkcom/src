using System;
using System.Globalization;
using System.Windows.Data;

namespace Niscon.Raynok.Converters
{
    public class NotNullBooleanConverter : IValueConverter
    {
        public bool Inverted { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Inverted
                ? value == null
                : value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
