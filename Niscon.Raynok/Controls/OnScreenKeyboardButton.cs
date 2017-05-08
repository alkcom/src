using System.Windows;
using System.Windows.Controls;

namespace Niscon.Raynok.Controls
{
    public class OnScreenKeyboardButton : Button
    {
        public static readonly DependencyProperty TextBoxProperty = DependencyProperty.Register(
            "TextBox", typeof(TextBox), typeof(OnScreenKeyboardButton), new PropertyMetadata(default(TextBox)));

        public TextBox TextBox
        {
            get { return (TextBox) GetValue(TextBoxProperty); }
            set { SetValue(TextBoxProperty, value); }
        }

        public string TextValue { get; set; }

        protected override void OnClick()
        {
            if (!string.IsNullOrEmpty(TextValue))
            {
                int caretIndex = TextBox.CaretIndex;
                TextBox.Text = TextBox.Text.Insert(TextBox.CaretIndex, TextValue);

                TextBox.CaretIndex = caretIndex + 1;
            }

            base.OnClick();

            TextBox.Focus();
        }
    }
}
