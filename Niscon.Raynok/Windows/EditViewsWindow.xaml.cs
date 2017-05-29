using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Windows
{
    /// <summary>
    /// Interaction logic for EditViewsWindow.xaml
    /// </summary>
    public partial class EditViewsWindow : Window
    {
        private bool _isDirty = false;

        public EditViewsWindow(ObservableCollection<View> views, List<Axis> axes)
        {
            InitializeComponent();

            Axes = new ObservableCollection<Axis>(axes);

            OriginalViews = views;
            ResetViews();
        }

        private void ResetViews()
        {
            Views = new ObservableCollection<View>(OriginalViews.Select(v => v.Clone()));
        }

        private ObservableCollection<View> OriginalViews { get; set; }

        public static readonly DependencyProperty ViewsProperty = DependencyProperty.Register(
            "Views", typeof(ObservableCollection<View>), typeof(EditViewsWindow), new PropertyMetadata(default(ObservableCollection<View>)));

        public ObservableCollection<View> Views
        {
            get { return (ObservableCollection<View>) GetValue(ViewsProperty); }
            private set { SetValue(ViewsProperty, value); }
        }

        public static readonly DependencyProperty SelectedViewProperty = DependencyProperty.Register(
            "SelectedView", typeof(View), typeof(EditViewsWindow), new PropertyMetadata(default(View)));

        public View SelectedView
        {
            get { return (View) GetValue(SelectedViewProperty); }
            set { SetValue(SelectedViewProperty, value); }
        }

        public static readonly DependencyProperty AxesProperty = DependencyProperty.Register(
            "Axes", typeof(ObservableCollection<Axis>), typeof(EditViewsWindow), new PropertyMetadata(default(ObservableCollection<Axis>)));

        public ObservableCollection<Axis> Axes
        {
            get { return (ObservableCollection<Axis>) GetValue(AxesProperty); }
            private set { SetValue(AxesProperty, value); }
        }

        private void Ok_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _isDirty;
        }

        private void Ok_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Cancel_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void New_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //lack of ID in view will mean that this is a new view
            //for example, this will help to determine if we should display view types list box
            EditViewWindow newViewWindow = new EditViewWindow
            {
                Header = "Add New View",
                Owner = this,
                View = new View
                {
                    IsVisible = true,
                    Axes = new ObservableCollection<Axis>(Axes)
                },
                Axes = new ObservableCollection<Axis>(Axes),
                AllowsTransparency = true,
                ExistingViews = Views
            };

            bool? result = newViewWindow.ShowDialog();

            if (result == true)
            {
                if (string.IsNullOrEmpty(newViewWindow.View.Name))
                {
                    MessageBoxWindow messageBox = new MessageBoxWindow
                    {
                        Header = "View error",
                        Message = $"Empty view name",
                        Owner = this,
                        Width = 400,
                        Height = 250
                    };

                    messageBox.ShowDialog();
                    return;
                }

                newViewWindow.View.Id = Guid.NewGuid();
                Views.Add(newViewWindow.View);

                _isDirty = true;
            }
        }

        private void ViewItem_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = SelectedView != null;
        }

        private void Edit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (SelectedView != null)
            {
                EditViewWindow viewSettingsWindow = new EditViewWindow
                {
                    Header = "Edit View",
                    Owner = this,
                    View = SelectedView.Clone(),
                    Axes = new ObservableCollection<Axis>(Axes),
                    AllowsTransparency = true,
                    ExistingViews = Views
                };

                bool? result = viewSettingsWindow.ShowDialog();

                if (result == true)
                {
                    if (string.IsNullOrEmpty(viewSettingsWindow.View.Name))
                    {
                        MessageBoxWindow messageBox = new MessageBoxWindow
                        {
                            Header = "View error",
                            Message = "Empty view name",
                            Owner = this,
                            Width = 400,
                            Height = 250
                        };

                        messageBox.ShowDialog();
                        return;
                    }

                    //view.Name = viewSettingsWindow.View.Name;
                    //view.Axes = new ObservableCollection<Axis>(viewSettingsWindow.View.Axes);

                    //if (view.IsSelected)
                    //{
                    //    viewSettingsWindow.View.IsSelected = true;
                    //}

                    Views.Insert(Views.IndexOf(SelectedView), viewSettingsWindow.View);
                    Views.Remove(SelectedView);

                    _isDirty = true;

                    //ReloadViews();
                }
            }
        }

        private void Delete_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (SelectedView != null)
            {
                if (Views.Count <= 1)
                {
                    MessageBoxWindow messageBox = new MessageBoxWindow
                    {
                        Header = "View deletion",
                        Message = "Last view cannot be deleted!",
                        Owner = this,
                        Width = 400,
                        Height = 250
                    };

                    messageBox.ShowDialog();
                    return;
                }

                ConfirmationWindow confirmationWindow = new ConfirmationWindow
                {
                    Header = "Deleting view...",
                    Message = $"Are you sure, you want to delete selected view - '{SelectedView.Name}'?",
                    Owner = this
                };

                bool? result = confirmationWindow.ShowDialog();

                if (result == true)
                {
                    Views.Remove(SelectedView);

                    //ReloadViews();

                    //View firstView = ViewModel.CurrentShow.Views.FirstOrDefault();
                    //if (firstView != null)
                    //{
                    //    firstView.IsSelected = true;
                    //}

                    _isDirty = true;
                }
            }
        }

        private void ResetChanges_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _isDirty;
        }

        private void ResetChanges_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ResetViews();
            _isDirty = false;
        }

        private void MoveUp_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (Views != null && SelectedView != null)
            {
                e.CanExecute = Views.IndexOf(SelectedView) > 0;
            }
        }

        private void MoveUp_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (Views != null && SelectedView != null)
            {
                int idx = Views.IndexOf(SelectedView);
                Views.Move(idx, idx - 1);

                _isDirty = true;
            }
        }

        private void MoveDown_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (Views != null && SelectedView != null)
            {
                e.CanExecute = Views.IndexOf(SelectedView) < Views.Count - 1;
            }
        }

        private void MoveDown_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (Views != null && SelectedView != null)
            {
                int idx = Views.IndexOf(SelectedView);
                Views.Move(idx, idx + 1);

                _isDirty = true;
            }
        }
    }
}
