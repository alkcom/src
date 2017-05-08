using System;
using System.Globalization;
using System.Windows.Data;
using Niscon.Raynok.Models;
using UnitsNet;

namespace Niscon.Raynok.Converters
{
    public class InchesToFeetConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double? doubleValue = value as double?;
            bool? boolParameter = parameter as bool?;
            if (doubleValue.HasValue)
            {
                Length length = Length.FromInches(doubleValue.Value);

                return length.FeetInches.Feet > 0
                    ? boolParameter.HasValue && boolParameter.Value
                        ? $"{length.FeetInches.Feet} - '{length.FeetInches.Inches}\""
                        : $"{length.FeetInches.Feet}'{length.FeetInches.Inches}\""
                    : $"{length.FeetInches.Inches}\"";
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class InchesToFeetMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double? inputLength = values[0] as double?;
            Units? units = values[1] as Units?;

            bool? boolParameter = parameter as bool?;

            if (inputLength.HasValue)
            {
                if (units.HasValue && units.Value == Units.FeetInches)
                {
                    Length length = Length.FromInches(inputLength.Value);

                    return length.FeetInches.Feet > 0
                        ? boolParameter.HasValue && boolParameter.Value
                            ? $"{length.FeetInches.Feet} - '{length.FeetInches.Inches}\""
                            : $"{length.FeetInches.Feet}'{length.FeetInches.Inches}\""
                        : $"{length.FeetInches.Inches}\"";
                }
                else
                {
                    return inputLength.ToString();
                }
            }

            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
