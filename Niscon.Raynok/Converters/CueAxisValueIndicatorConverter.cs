using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Converters
{
    public enum CueAxisValueIndicatorConverterParameter
    {
        BoundsTop,
        BoundsMiddle,
        BoundsBottom,
        CurrentTop,
        CurrentBottom
    }

    public class CueAxisValueIndicatorConverter : IValueConverter, IMultiValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
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

                double resultValue = 1;
                double length = maxValue - minValue;
                switch (indicatorParameter.Value)
                {
                    case CueAxisValueIndicatorConverterParameter.BoundsTop:
                        if (upperValue != double.MaxValue)
                        {
                            resultValue = (maxValue - upperValue) / length;
                        }
                        break;
                    case CueAxisValueIndicatorConverterParameter.BoundsMiddle:
                        if (upperValue != double.MaxValue && lowerValue != double.MinValue)
                        {
                            resultValue = (upperValue - lowerValue) / length;
                        }
                        break;
                    case CueAxisValueIndicatorConverterParameter.BoundsBottom:
                        if (lowerValue != double.MinValue)
                        {
                            resultValue = (lowerValue - minValue) / length;
                        }
                        break;
                    case CueAxisValueIndicatorConverterParameter.CurrentTop:
                        resultValue = (maxValue - currentValue) / length;
                        break;
                    case CueAxisValueIndicatorConverterParameter.CurrentBottom:
                        resultValue = (currentValue - minValue) / length;
                        break;
                }

                return new GridLength(resultValue, GridUnitType.Star);
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
