using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Niscon.Raynok.Helpers;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Controls
{
    /// <summary>
    /// Interaction logic for AxesGrid.xaml
    /// </summary>
    public partial class AxesGrid : AxesDisplayControl
    {
        public AxesGrid()
        {
            InitializeComponent();

            CueAxesDataGrid.MouseUp += CueAxesDataGrid_MouseUp;
        }

        public event CurrentValueDialogRequestedEventHandler CurrentValueDialogRequested;

        protected void OnCurrentValueDialogRequested(Axis axis)
        {
            CurrentValueDialogRequested?.Invoke(this, new CurrentValueDialogRequestedEventArgs(axis));
        }

        private void CueAxesDataGrid_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //a bit ugly solution, but the native one (data grid selection) does not work as expected
            DataGrid grid = sender as DataGrid;
            if (grid != null)
                foreach (object item in grid.Items)
                {
                    DataGridRow dgr = (DataGridRow) grid.ItemContainerGenerator.ContainerFromItem(item);
                    if (dgr != null && dgr.IsMouseOver)
                    {
                        Profile profile = (Profile) dgr.DataContext;
                        profile.ToggleAxisSelectedState();
                        //cueAxis.State = cueAxis.State == AxisState.Active ? AxisState.Inactive : AxisState.Active;

                        break;
                    }
                }
        }

        public static readonly DependencyProperty AppSettingsProperty = DependencyProperty.Register(
            "AppSettings", typeof(AppSettings), typeof(AxesGrid), new PropertyMetadata(default(AppSettings)));

        public AppSettings AppSettings
        {
            get { return (AppSettings) GetValue(AppSettingsProperty); }
            set { SetValue(AppSettingsProperty, value); }
        }

        private void UIElement_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            LockPanel.Visibility = Visibility.Visible;

            e.Handled = true;
        }

        private void Control_OnPreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Profile profile = (sender as Label)?.DataContext as Profile;
            if (profile != null)
            {
                OnCurrentValueDialogRequested(profile.Axis);
            }

            e.Handled = true;
        }

        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }
    }
}
