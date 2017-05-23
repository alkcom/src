using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Converters
{
    public class CueTreeItemsConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<Cue> nodes = values[0] as ObservableCollection<Cue>;
            ObservableCollection<Cue> specialNodes = values[1] as ObservableCollection<Cue>;

            if (nodes != null && specialNodes != null)
            {
                return nodes.Union(specialNodes).ToList();
            }

            return new List<Cue>();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
