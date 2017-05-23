using System.Linq;
using System.Windows;
using System.Windows.Input;
using Niscon.Raynok.Extensions;
using Niscon.Raynok.Helpers;
using UnitsNet;
using UnitsNet.Units;

namespace Niscon.Raynok.Windows
{
    /// <summary>
    /// Interaction logic for EditValueWindow.xaml
    /// </summary>
    public partial class EditValueWindow : Window
    {
        private const string Modifiers = "<>";

        public EditValueWindow()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty NewValueProperty = DependencyProperty.Register(
            "NewValue", typeof(string), typeof(EditValueWindow), new PropertyMetadata(default(string)));

        public string NewValue
        {
            get { return (string) GetValue(NewValueProperty); }
            set { SetValue(NewValueProperty, value); }
        }

        private void OkButton_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            //Axis.CurrentValue = double.Parse(CurrentValueText.Text);

            DialogResult = true;
            Close();
        }

        private void CancelButton_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void MoveLeftButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (CurrentValueText.CaretIndex > 0)
            {
                CurrentValueText.CaretIndex--;
            }
        }

        private void MoveRightButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (CurrentValueText.CaretIndex < CurrentValueText.Text.Length)
            {
                CurrentValueText.CaretIndex++;
            }
        }

        private void ClrButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentValueText.Text = string.Empty;
        }

        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            LengthUnit unit = GetTextWithoutModifiers().ParseLengthUnit();
            Length length = GetTextWithoutModifiers().ParseLength();

            if (length > Length.Zero)
            {
                length = length * -1;

                SetTextWithoutModifiers(length.ToStringFixed(unit));
            }
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            LengthUnit unit = GetTextWithoutModifiers().ParseLengthUnit();
            Length length = GetTextWithoutModifiers().ParseLength();

            if (length < Length.Zero)
            {
                length = length * -1;

                SetTextWithoutModifiers(length.ToStringFixed(unit));
            }
        }

        private void GtButton_Click(object sender, RoutedEventArgs e)
        {
            SetModifier('>');
        }

        private void LtButton_Click(object sender, RoutedEventArgs e)
        {
            SetModifier('<');
        }

        private char? GetTextModifier()
        {
            return CurrentValueText.Text.GetModifier();
        }

        private string GetTextWithoutModifiers()
        {
            return CurrentValueText.Text.GetTextWithoutModifiers();
        }

        private void SetTextWithoutModifiers(string value)
        {
            char? modifier = GetTextModifier();

            CurrentValueText.Text = modifier != null ? $"{modifier}{value}" : value;
        }

        private void BackspaceButton_Click(object sender, RoutedEventArgs e)
        {
            int caretIndex = CurrentValueText.CaretIndex;
            if (caretIndex > 0)
            {
                CurrentValueText.Text = CurrentValueText.Text.Remove(CurrentValueText.CaretIndex - 1, 1);
                CurrentValueText.CaretIndex = caretIndex - 1;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            int caretIndex = CurrentValueText.CaretIndex;
            if (caretIndex < CurrentValueText.Text.Length)
            {
                CurrentValueText.Text = CurrentValueText.Text.Remove(CurrentValueText.CaretIndex, 1);
                CurrentValueText.CaretIndex = caretIndex;
            }
        }

        /// <summary>
        /// Validating text after quote button has been pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventargs"></param>
        private void QuoteButton_Validate(object sender, OnScreenKeyboardButtonValidateEventArgs eventargs)
        {
            Length tmp;
            eventargs.IsValid = Length.TryParse(eventargs.NewText, out tmp);
        }

        /// <summary>
        /// Validating text after apostrophe button has been pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventargs"></param>
        private void ApostropheButton_Validate(object sender, OnScreenKeyboardButtonValidateEventArgs eventargs)
        {
            Length tmp;
            eventargs.IsValid = Length.TryParse(eventargs.NewText, out tmp);
        }

        private void AsteriskButton_Click(object sender, RoutedEventArgs e)
        {
            SetModifier('*');
        }

        private void SetModifier(char modifier)
        {
            CurrentValueText.Text = $"{modifier}{GetTextWithoutModifiers()}";
        }

        private void EscButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
