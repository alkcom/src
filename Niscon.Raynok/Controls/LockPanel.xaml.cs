using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Niscon.Raynok.Controls
{
    /// <summary>
    /// Interaction logic for LockPanel.xaml
    /// </summary>
    public partial class LockPanel : UserControl
    {
        public LockPanel()
        {
            InitializeComponent();
        }

        private void SetupButton_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void OkButton_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        private void CancelButton_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }
    }
}
