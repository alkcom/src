using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Converters
{
    public class AdminMenuItemVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string menuItemName = (value as AdminMenuItem)?.Name;
            return (parameter is string && !string.IsNullOrEmpty(menuItemName) && menuItemName.Equals(parameter))
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility? visibility = value as Visibility?;
            string str = parameter as string;
            return (visibility.HasValue && !string.IsNullOrEmpty(str) && visibility.Value == Visibility.Visible)
                ? new AdminMenuItem(str)
                : null;
        }
    }
}
