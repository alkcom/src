using System.Windows;
using System.Windows.Controls;
using Niscon.Raynok.Helpers;

namespace Niscon.Raynok.Controls
{
    public class OnScreenKeyboardButton : Button
    {
        public event OnScreenKeyboardButtonValidateEventHandler Validate;

        public static readonly DependencyProperty TextBoxProperty = DependencyProperty.Register(
            "TextBox", typeof(TextBox), typeof(OnScreenKeyboardButton), new PropertyMetadata(default(TextBox)));

        public TextBox TextBox
        {
            get { return (TextBox) GetValue(TextBoxProperty); }
            set { SetValue(TextBoxProperty, value); }
        }

        public string TextValue { get; set; }

        protected virtual void OnValidate(OnScreenKeyboardButtonValidateEventArgs eventArgs)
        {
            Validate?.Invoke(this, eventArgs);
        }

        protected override void OnClick()
        {
            if (!string.IsNullOrEmpty(TextValue))
            {
                int caretIndex = TextBox.CaretIndex;
                string newText = TextBox.Text.Insert(TextBox.CaretIndex, TextValue);

                OnScreenKeyboardButtonValidateEventArgs ea = new OnScreenKeyboardButtonValidateEventArgs(TextBox.Text, newText);
                OnValidate(ea);

                if (ea.IsValid)
                {
                    TextBox.Text = newText;

                    TextBox.CaretIndex = caretIndex + 1;
                }
            }

            base.OnClick();

            TextBox.Focus();
        }
    }
}
