using System.Windows;
using System.Windows.Controls;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Controls
{
    /// <summary>
    /// Interaction logic for SetupPanel.xaml
    /// </summary>
    public partial class SetupPanel : UserControl
    {
        public SetupPanel()
        {
            InitializeComponent();
        }

        private void MakeTransparentButton_Click(object sender, RoutedEventArgs e)
        {
            Opacity = 0.3;
        }

        private void MakeVisibleButton_Click(object sender, RoutedEventArgs e)
        {
            Opacity = 1;
        }

        public static readonly DependencyProperty AppSettingsProperty = DependencyProperty.Register(
            "AppSettings", typeof(AppSettings), typeof(SetupPanel), new PropertyMetadata(default(AppSettings)));

        public AppSettings AppSettings
        {
            get { return (AppSettings) GetValue(AppSettingsProperty); }
            set { SetValue(AppSettingsProperty, value); }
        }
    }
}
