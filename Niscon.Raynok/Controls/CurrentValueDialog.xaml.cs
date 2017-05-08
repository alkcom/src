using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Controls
{
    /// <summary>
    /// Interaction logic for CurrentValueDialog.xaml
    /// </summary>
    public partial class CurrentValueDialog : UserControl
    {
        public CurrentValueDialog()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty AxisProperty = DependencyProperty.Register(
            "Axis", typeof(Axis), typeof(CurrentValueDialog), new PropertyMetadata(default(Axis)));

        public Axis Axis
        {
            get { return (Axis) GetValue(AxisProperty); }
            set { SetValue(AxisProperty, value); }
        }

        public void Show()
        {
            CurrentValueText.Text = Axis.CurrentValue.ToString();

            Visibility = Visibility.Visible;

            CurrentValueText.Focus();
        }

        private void OkButton_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Axis.CurrentValue = double.Parse(CurrentValueText.Text);

            Visibility = Visibility.Collapsed;
        }

        private void CancelButton_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Visibility = Visibility.Collapsed;
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
    }
}
