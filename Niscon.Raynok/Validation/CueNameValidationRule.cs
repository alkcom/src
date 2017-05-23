using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Validation
{
    public class CueNameValidationRule : ValidationRule
    {
        public ObservableCollection<Cue> Cues { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Cues == null)
            {
                return new ValidationResult(false, "Empty cue list");
            }

            string stringValue = value as string;
            if (string.IsNullOrEmpty(stringValue))
            {
                return new ValidationResult(false, "Cue name cannot be empty");
            }

            return ValidateCues(Cues, stringValue)
                ? new ValidationResult(true, string.Empty)
                : new ValidationResult(false, "Cue with the same name already exist");
        }

        /// <summary>
        /// Traverse through all the cues to find ones with matching name
        /// </summary>
        /// <param name="cues"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ValidateCues(ObservableCollection<Cue> cues, string name)
        {
            foreach (Cue cue in cues)
            {
                if (cue.Name.Equals(name))
                {
                    return false;
                }

                if (cue.Children?.Any() == true)
                {
                    if (!ValidateCues(cue.Children, name))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
