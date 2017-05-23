using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Validation
{
    public class ViewNameValidationRule : ValidationRule
    {
        public ObservableCollection<View> Views { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Views == null)
            {
                return new ValidationResult(false, "Empty views list");
            }

            string stringValue = value as string;
            if (string.IsNullOrEmpty(stringValue))
            {
                return new ValidationResult(false, "View name cannot be empty");
            }

            foreach (View view in Views)
            {
                if (view.Name.Equals(stringValue))
                {
                    return new ValidationResult(false, "View with the same name already exist");
                }
            }

            return new ValidationResult(true, string.Empty);
        }
    }
}
