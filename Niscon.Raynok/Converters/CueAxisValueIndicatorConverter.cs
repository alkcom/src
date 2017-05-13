using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Converters
{
    public enum CueAxisValueIndicatorConverterParameter
    {
        Top,
        TopMiddle,
        BottomMiddle,
        Bottom
    }

    public class CueAxisValueIndicatorConverter : IValueConverter, IMultiValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Profile profile = value as Profile;
            CueAxisValueIndicatorConverterParameter? indicatorParameter = parameter as CueAxisValueIndicatorConverterParameter?;

            if (profile != null && indicatorParameter.HasValue)
            {
                double upperValue = double.MaxValue;
                double lowerValue = double.MinValue;

                // settings upper and lower bounds from start and target values
                if (profile.Direction == AxisDirection.Down)
                {
                    upperValue = profile.StartValue;
                    lowerValue = profile.TargetValue;
                }
                else if (profile.Direction == AxisDirection.Up)
                {
                    upperValue = profile.TargetValue;
                    lowerValue = profile.StartValue;
                }

                if (upperValue != double.MaxValue && lowerValue != double.MinValue)
                {
                    double resultValue = 1;
                    double length = profile.Axis.MaxValue - profile.Axis.MinValue;
                    switch (indicatorParameter.Value)
                    {
                        case CueAxisValueIndicatorConverterParameter.Top:
                            resultValue = (profile.Axis.MaxValue - upperValue) / length;
                            break;
                        case CueAxisValueIndicatorConverterParameter.TopMiddle:
                            //if current value is out of bounds of (upper;lower), set height of the upper middle portion to half of distance between upper and lower value
                            if (profile.Axis.CurrentValue > lowerValue && profile.Axis.CurrentValue < upperValue)
                            {
                                resultValue = (upperValue - profile.Axis.CurrentValue) / length;
                            }
                            else
                            {
                                resultValue = (upperValue - lowerValue) / (length*2);
                            }
                            break;
                        case CueAxisValueIndicatorConverterParameter.BottomMiddle:
                            //if current value is out of bounds of (upper;lower), set height of the lower middle portion to half of distance between upper and lower value
                            if (profile.Axis.CurrentValue > lowerValue && profile.Axis.CurrentValue < upperValue)
                            {
                                resultValue = (profile.Axis.CurrentValue - lowerValue) / length;
                            }
                            else
                            {
                                resultValue = (upperValue - lowerValue) / (length * 2);
                            }
                            break;
                        case CueAxisValueIndicatorConverterParameter.Bottom:
                            resultValue = (lowerValue - profile.Axis.MinValue) / length;
                            break;
                    }

                    return new GridLength(resultValue, GridUnitType.Star);
                }
            }

            return new GridLength(1, GridUnitType.Star);
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double startValue = (double)values[0];
            double targetValue = (double)values[1];
            double minValue = (double)values[2];
            double maxValue = (double)values[3];
            double currentValue = (double)values[4];

            CueAxisValueIndicatorConverterParameter? indicatorParameter = parameter as CueAxisValueIndicatorConverterParameter?;

            double upperValue = double.MaxValue;
            double lowerValue = double.MinValue;

            if (indicatorParameter.HasValue)
            {
                if (startValue > targetValue)
                {
                    upperValue = startValue;
                    lowerValue = targetValue;
                }
                else if (startValue < targetValue)
                {
                    upperValue = targetValue;
                    lowerValue = startValue;
                }

                if (upperValue != double.MaxValue && lowerValue != double.MinValue)
                {
                    double resultValue = 1;
                    double length = maxValue - minValue;
                    switch (indicatorParameter.Value)
                    {
                        case CueAxisValueIndicatorConverterParameter.Top:
                            resultValue = (maxValue - upperValue) / length;
                            break;
                        case CueAxisValueIndicatorConverterParameter.TopMiddle:
                            //if current value is out of bounds of (upper;lower), set height of the upper middle portion to half of distance between upper and lower value
                            if (currentValue > lowerValue && currentValue < upperValue)
                            {
                                resultValue = (upperValue - currentValue) / length;
                            }
                            else
                            {
                                resultValue = (upperValue - lowerValue) / (length * 2);
                            }
                            break;
                        case CueAxisValueIndicatorConverterParameter.BottomMiddle:
                            //if current value is out of bounds of (upper;lower), set height of the lower middle portion to half of distance between upper and lower value
                            if (currentValue > lowerValue && currentValue < upperValue)
                            {
                                resultValue = (currentValue - lowerValue) / length;
                            }
                            else
                            {
                                resultValue = (upperValue - lowerValue) / (length * 2);
                            }
                            break;
                        case CueAxisValueIndicatorConverterParameter.Bottom:
                            resultValue = (lowerValue - minValue) / length;
                            break;
                    }

                    return new GridLength(resultValue, GridUnitType.Star);
                }
            }

            return new GridLength(1, GridUnitType.Star);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
