using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Niscon.Raynok.Converters
{
    /// <summary>
    /// Converts number of input enums and bool values into visibility for selected control.
    /// One-way binding only.
    /// </summary>
    public class BackgroundLogoVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility visibility = Visibility.Visible;
            foreach (object value in values)
            {
                bool? boolValue = value as bool?;
                if ((boolValue.HasValue && boolValue.Value) || (value is Enum && System.Convert.ToInt32(value) > 0))
                {
                    visibility = Visibility.Collapsed;
                    break;
                }
            }

            return visibility;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
