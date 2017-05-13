using System.Windows;
using System.Windows.Input;

namespace Niscon.Raynok.Windows
{
    /// <summary>
    /// Interaction logic for CuePropertiesWindow.xaml
    /// </summary>
    public partial class CuePropertiesWindow : Window
    {
        public CuePropertiesWindow()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
            "Header", typeof(string), typeof(CuePropertiesWindow), new PropertyMetadata(default(string)));

        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty NewValueProperty = DependencyProperty.Register(
            "NewValue", typeof(string), typeof(CuePropertiesWindow), new PropertyMetadata(default(string)));

        public string NewValue
        {
            get { return (string)GetValue(NewValueProperty); }
            set { SetValue(NewValueProperty, value); }
        }

        private void OkButton_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void CancelButton_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
