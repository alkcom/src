using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Converters
{
    public class CurrentValueIndicatorVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Profile profile = value as Profile;

            Visibility result = Visibility.Collapsed;
            if (profile != null && profile.Axis != null)
            {
                if (profile.State == AxisState.Active || profile.State == AxisState.Error)
                {
                    if ((profile.StartValue > profile.TargetValue && profile.Axis.CurrentValue < profile.StartValue &&
                         profile.Axis.CurrentValue > profile.TargetValue) ||
                        (profile.StartValue < profile.TargetValue && profile.Axis.CurrentValue > profile.StartValue &&
                         profile.Axis.CurrentValue < profile.TargetValue))
                    {
                        result = Visibility.Visible;
                    }
                }
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
