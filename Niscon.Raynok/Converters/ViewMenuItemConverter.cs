using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using Niscon.Raynok.Commands;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Converters
{
    public class ViewMenuItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            View view = value as View;
            if (view == null)
            {
                return null;
            }

            return new MenuItem { Header = view.Name, Command = ViewCommands.Select, CommandParameter = view, IsCheckable = true, IsChecked = view.IsVisible };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ViewsMenuItemsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<View> views = value as List<View>;
            if (views == null || !views.Any())
            {
                return null;
            }

            return views.Select(
                v => new MenuItem {Header = v.Name, Command = ViewCommands.Select, CommandParameter = v, IsCheckable = true, IsChecked = v.IsVisible});
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
