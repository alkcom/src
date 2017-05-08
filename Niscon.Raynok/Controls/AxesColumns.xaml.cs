using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Niscon.Raynok.Helpers;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Controls
{
    /// <summary>
    /// Interaction logic for AxesColumns.xaml
    /// </summary>
    public partial class AxesColumns : AxesDisplayControl
    {
        public AxesColumns()
        {
            InitializeComponent();

            AxesWidgetsListBox.MouseUp += AxesWidgetsListBox_MouseUp;
        }

        private void AxesWidgetsListBox_MouseUp(object sender, MouseButtonEventArgs e)
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

        private ScrollViewer GetScrollViewer()
        {
            if (AxesWidgetsListBox.Items.Count > 0)
            {
                Grid grid = VisualTreeHelper.GetChild(AxesWidgetsListBox, 0) as Grid;
                if (grid != null)
                {
                    Decorator border = VisualTreeHelper.GetChild(grid, 0) as Decorator;
                    if (border != null)
                    {
                        ScrollViewer scroll = border.Child as ScrollViewer;
                        return scroll;
                    }
                }
            }

            return null;
        }

        public static readonly DependencyProperty AppSettingsProperty = DependencyProperty.Register(
            "AppSettings", typeof(AppSettings), typeof(AxesColumns), new PropertyMetadata(default(AppSettings)));

        public AppSettings AppSettings
        {
            get { return (AppSettings) GetValue(AppSettingsProperty); }
            set { SetValue(AppSettingsProperty, value); }
        }

        private void AxisColumnValueIndicator_OnLockOptionsRequested(object sender, LockOptionsRequesetedEventArgs eventargs)
        {
            LockPanel.Visibility = Visibility.Visible;
        }
    }
}
