using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Converters
{
    public class ViewsSelectedViewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<View> views = value as ObservableCollection<View>;

            if (views == null || !views.Any())
            {
                return null;
            }

            foreach (View view in views)
            {
                if (view.IsSelected)
                {
                    return view.Id;
                }
            }

            //if 
            View first = views.First();
            first.IsSelected = true;

            return first.Id;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
