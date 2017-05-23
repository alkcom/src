using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Converters
{
    class AxesProfilesMatchingConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == DependencyProperty.UnsetValue)
            {
                return null;
            }

            Dictionary<int, Profile> profiles = ((IList<Profile>)values[0]).ToDictionary(p => p.AxisId);
            IList<Axis> axes = (IList<Axis>) values[1];

            List<Profile> resultingProfiles = new List<Profile>();
            foreach (Axis axis in axes)
            {
                if (profiles.ContainsKey(axis.Id))
                {
                    resultingProfiles.Add(profiles[axis.Id]);
                }
            }

            return resultingProfiles;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
