using System.Windows;

namespace Niscon.Raynok.Converters
{
    public class CustomBooleanVisibilityConverter : BooleanConverter<Visibility>
    {
        public CustomBooleanVisibilityConverter() : base(Visibility.Visible, Visibility.Hidden)
        {
        }
    }
}
