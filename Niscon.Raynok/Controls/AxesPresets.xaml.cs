using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Controls
{
    /// <summary>
    /// Interaction logic for AxesPresets.xaml
    /// </summary>
    public partial class AxesPresets : AxesDisplayControl
    {
        public AxesPresets()
        {
            InitializeComponent();

            CueAxisParametersListBox.MouseUp += CueAxisParametersListBox_MouseUp;
        }

        private void CueAxisParametersListBox_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ListBox listbox = sender as ListBox;
            if (listbox != null)
            {
                foreach (object item in listbox.Items)
                {
                    ListBoxItem lbItem = (ListBoxItem)listbox.ItemContainerGenerator.ContainerFromItem(item);
                    if (lbItem != null && lbItem.IsMouseOver)
                    {
                        Profile profile = (Profile)lbItem.DataContext;
                        profile.ToggleAxisSelectedState();
                        //cueAxis.State = cueAxis.State == AxisState.Active ? AxisState.Inactive : AxisState.Active;

                        break;
                    }
                }
            }
        }

        public static readonly DependencyProperty AppSettingsProperty = DependencyProperty.Register(
            "AppSettings", typeof(AppSettings), typeof(AxesPresets), new PropertyMetadata(default(AppSettings)));

        public AppSettings AppSettings
        {
            get { return (AppSettings) GetValue(AppSettingsProperty); }
            set { SetValue(AppSettingsProperty, value); }
        }

        private void LockImage_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            LockPanel.Visibility = Visibility.Visible;

            e.Handled = true;
        }
    }
}
