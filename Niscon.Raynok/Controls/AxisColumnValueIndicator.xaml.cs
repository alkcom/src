using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Niscon.Raynok.Helpers;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Controls
{
    /// <summary>
    /// Interaction logic for AxisColumnValueIndicator.xaml
    /// </summary>
    public partial class AxisColumnValueIndicator : UserControl
    {
        public AxisColumnValueIndicator()
        {
            InitializeComponent();
        }

        public event LockOptionsRequestedEventHandler LockOptionsRequested;

        protected void OnLockOptionsRequested(Profile profile)
        {
            LockOptionsRequested?.Invoke(this, new LockOptionsRequesetedEventArgs(profile));
        }

        public static readonly DependencyProperty ProfileProperty = DependencyProperty.Register(
            "Profile", typeof(Profile), typeof(AxisColumnValueIndicator), new PropertyMetadata(default(Profile)));

        public Profile Profile
        {
            get { return (Profile)GetValue(ProfileProperty); }
            set { SetValue(ProfileProperty, value); }
        }

        public static readonly DependencyProperty AppSettingsProperty = DependencyProperty.Register(
            "AppSettings", typeof(AppSettings), typeof(AxisColumnValueIndicator), new PropertyMetadata(default(AppSettings)));

        public AppSettings AppSettings
        {
            get { return (AppSettings) GetValue(AppSettingsProperty); }
            set { SetValue(AppSettingsProperty, value); }
        }

        private void LockImage_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            OnLockOptionsRequested(Profile);

            e.Handled = true;
        }
    }
}
