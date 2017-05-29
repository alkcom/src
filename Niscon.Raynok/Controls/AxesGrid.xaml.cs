using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Niscon.Raynok.Extensions;
using Niscon.Raynok.Helpers;
using Niscon.Raynok.Models;
using Niscon.Raynok.Windows;
using UnitsNet;

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

        public event ProfilesUpdatedEventHandler ProfilesUpdated;

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

        private void CurrentValue_OnPreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Profile profile = (sender as Label)?.DataContext as Profile;
            if (profile != null && profile.State != AxisState.Disabled)
            {
                EditValueWindow editValueWindow = new EditValueWindow
                {
                    NewValue = profile.Axis.CurrentValue.ToString(),
                    Owner = Application.Current.MainWindow,
                };

                bool? result = editValueWindow.ShowDialog();

                if (result == true)
                {
                    char? modifier = editValueWindow.NewValue.GetModifier();
                    string text = editValueWindow.NewValue.GetTextWithoutModifiers();

                    Length length = text.ParseLength();

                    switch (modifier)
                    {
                        case null:
                            profile.Axis.CurrentValue = length.Inches;
                            break;
                        case '*':
                            profile.Axis.CurrentValue *= length.Inches;
                            break;
                        case '>':
                            profile.Axis.CurrentValue += length.Inches;
                            break;
                        case '<':
                            profile.Axis.CurrentValue -= length.Inches;
                            break;
                    }
                }

                InvertProfileSelection(profile);
            }

            //e.Handled = true;
        }

        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //e.Handled = true;
        }

        private void TargetValue_OnPreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Profile profile = (sender as Label)?.DataContext as Profile;
            if (profile != null && profile.State != AxisState.Disabled)
            {
                EditValueWindow editValueWindow = new EditValueWindow
                {
                    NewValue = profile.TargetValue.ToString(),
                    Owner = Application.Current.MainWindow,
                };

                bool? result = editValueWindow.ShowDialog();

                if (result == true)
                {
                    char? modifier = editValueWindow.NewValue.GetModifier();
                    string text = editValueWindow.NewValue.GetTextWithoutModifiers();

                    Length length = text.ParseLength();

                    switch (modifier)
                    {
                        case null:
                            profile.TargetValue = length.Inches;
                            break;
                        case '*':
                            profile.TargetValue *= length.Inches;
                            break;
                        case '>':
                            profile.TargetValue += length.Inches;
                            break;
                        case '<':
                            profile.TargetValue -= length.Inches;
                            break;
                    }

                    OnProfilesUpdated(new ProfilesUpdatedEventArgs(new List<Profile> {profile}));
                }

                InvertProfileSelection(profile);
            }

            //e.Handled = true;
        }

        protected virtual void OnProfilesUpdated(ProfilesUpdatedEventArgs eventargs)
        {
            ProfilesUpdated?.Invoke(this, eventargs);
        }

        private void Velocity_OnPreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Profile profile = (sender as Label)?.DataContext as Profile;
            if (profile != null && profile.State != AxisState.Disabled)
            {
                EditValueWindow editValueWindow = new EditValueWindow
                {
                    NewValue = profile.Velocity.ToString(),
                    Owner = Application.Current.MainWindow,
                };

                bool? result = editValueWindow.ShowDialog();

                if (result == true)
                {
                    char? modifier = editValueWindow.NewValue.GetModifier();
                    string text = editValueWindow.NewValue.GetTextWithoutModifiers();

                    Length length = text.ParseLength();

                    switch (modifier)
                    {
                        case null:
                            profile.Velocity = length.Inches;
                            break;
                        case '*':
                            profile.Velocity *= length.Inches;
                            break;
                        case '>':
                            profile.Velocity += length.Inches;
                            break;
                        case '<':
                            profile.Velocity -= length.Inches;
                            break;
                    }
                }

                InvertProfileSelection(profile);
            }

            //e.Handled = true;
        }

        private void Acceleration_OnPreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Profile profile = (sender as Label)?.DataContext as Profile;
            if (profile != null && profile.State != AxisState.Disabled)
            {
                EditValueWindow editValueWindow = new EditValueWindow
                {
                    NewValue = profile.Acceleration.ToString(),
                    Owner = Application.Current.MainWindow,
                };

                bool? result = editValueWindow.ShowDialog();

                if (result == true)
                {
                    char? modifier = editValueWindow.NewValue.GetModifier();
                    string text = editValueWindow.NewValue.GetTextWithoutModifiers();

                    Length length = text.ParseLength();

                    switch (modifier)
                    {
                        case null:
                            profile.Acceleration = length.Inches;
                            break;
                        case '*':
                            profile.Acceleration *= length.Inches;
                            break;
                        case '>':
                            profile.Acceleration += length.Inches;
                            break;
                        case '<':
                            profile.Acceleration -= length.Inches;
                            break;
                    }
                }

                InvertProfileSelection(profile);
            }

            //e.Handled = true;
        }

        private void Deceleration_OnPreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Profile profile = (sender as Label)?.DataContext as Profile;
            if (profile != null && profile.State != AxisState.Disabled)
            {
                EditValueWindow editValueWindow = new EditValueWindow
                {
                    NewValue = profile.Deceleration.ToString(),
                    Owner = Application.Current.MainWindow,
                };

                bool? result = editValueWindow.ShowDialog();

                if (result == true)
                {
                    char? modifier = editValueWindow.NewValue.GetModifier();
                    string text = editValueWindow.NewValue.GetTextWithoutModifiers();

                    Length length = text.ParseLength();

                    switch (modifier)
                    {
                        case null:
                            profile.Deceleration = length.Inches;
                            break;
                        case '*':
                            profile.Deceleration *= length.Inches;
                            break;
                        case '>':
                            profile.Deceleration += length.Inches;
                            break;
                        case '<':
                            profile.Deceleration -= length.Inches;
                            break;
                    }
                }

                InvertProfileSelection(profile);
            }

            //e.Handled = true;
        }

        private void InvertProfileSelection(Profile profile)
        {
            if (profile != null)
            {
                profile.Axis.Selected = !profile.Axis.Selected;
            }
        }
    }
}
