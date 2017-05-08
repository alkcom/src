using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Converters
{
    public class NamedItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IEnumerable<NamedItem> itemList = (IEnumerable<NamedItem>) parameter;
            if (itemList != null && value != null)
            {
                foreach (NamedItem item in itemList)
                {
                    if (value.Equals(item.Item))
                    {
                        return item;
                    }
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            NamedItem namedItemValue = (NamedItem) value;

            return namedItemValue?.Item;
        }
    }
}
