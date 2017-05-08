using System.Windows;
using System.Windows.Controls;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Controls
{
    /// <summary>
    /// Interaction logic for AxisValueIndicator.xaml
    /// </summary>
    public partial class AxisValueIndicator : UserControl
    {
        public AxisValueIndicator()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ProfileProperty = DependencyProperty.Register(
            "Profile", typeof(Profile), typeof(AxisValueIndicator), new PropertyMetadata(default(Profile)));

        public Profile Profile
        {
            get { return (Profile) GetValue(ProfileProperty); }
            set { SetValue(ProfileProperty, value); }
        }

        public static readonly DependencyProperty AppSettingsProperty = DependencyProperty.Register(
            "AppSettings", typeof(AppSettings), typeof(AxisValueIndicator), new PropertyMetadata(default(AppSettings)));

        public AppSettings AppSettings
        {
            get { return (AppSettings) GetValue(AppSettingsProperty); }
            set { SetValue(AppSettingsProperty, value); }
        }
    }
}
