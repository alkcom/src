using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Niscon.Raynok.Converters
{
    public class TabItemIndexConverter : IValueConverter
    {
        public bool Reverse { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TabItem tabItem = value as TabItem;

            ItemsControl itemControl = ItemsControl.ItemsControlFromItemContainer(tabItem);
            int totalItems = itemControl.ItemContainerGenerator.Items.Count;
            int index = itemControl.ItemContainerGenerator.IndexFromContainer(tabItem);

            return Reverse ? totalItems - index : index + 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
