using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Converters
{
    public class AdminMenuItemRaynokModeConverter : IValueConverter
    {
        private const RaynokStates Default = RaynokStates.Offline;

        private static readonly Dictionary<string, RaynokStates> Map = new Dictionary<string, RaynokStates>
        {
            {"Raynok Online", RaynokStates.Online },
            //{"Raynok Edit Mode", RaynokStates.Edit },
            {"Raynok Off Line", RaynokStates.Offline }
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            AdminMenuItem menuItemValue = value as AdminMenuItem;

            if (menuItemValue == null || string.IsNullOrEmpty(menuItemValue.Name))
            {
                return null;
            }

            if (!Map.ContainsKey(menuItemValue.Name))
            {
                return Default;
            }

            return Map[menuItemValue.Name];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
