using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using Niscon.Raynok.Commands;
using Niscon.Raynok.Controls;
using Niscon.Raynok.Extensions;
using Niscon.Raynok.Helpers;
using Niscon.Raynok.Models;
using Niscon.Raynok.Services;
using Niscon.Raynok.ViewModels;
using Niscon.Raynok.Windows;

namespace Niscon.Raynok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly ShowsService _showsService;

        private MainWindowViewModel ViewModel => (MainWindowViewModel) DataContext;

        public MainWindow(ShowsService showsService)
        {
            _showsService = showsService;

            InitializeComponent();

            DependencyPropertyDescriptor adminMenuIsCheckedDescriptor = DependencyPropertyDescriptor.FromProperty(ToggleButton.IsCheckedProperty, typeof(ToggleButton));
            adminMenuIsCheckedDescriptor.AddValueChanged(SettingsMenuButton, (sender, args) =>
            {
                if (SettingsMenuButton.IsChecked != null)
                {   //work around to hide panels when menu is closing
                    if (!SettingsMenuButton.IsChecked.Value)
                    {
                        AdminMenuContainer.SelectedValue = null;
                    }
                }
            });

            DataContext = new MainWindowViewModel
            {
                AppSettings = new AppSettings
                {
                    Units = Units.Inches
                }
            };

            ReloadAxes();
            ReloadShows();

            //if you want to affect visual state of some control, use bindings - declarative approach; use programatic methods as a last resort
        }

        private void CloseAppCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CloseAppCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ReloadShows()
        {
            List<ShowFile> shows = _showsService.GetShowFiles();

            List<MenuItem> menuItems =
                shows.Select(
                    s => new MenuItem {Header = s.Name, Command = ShowCommands.Open, CommandParameter = s}).ToList();

            ViewModel.ShowsMenuItems = menuItems;
        }

        private void ReloadAxes()
        {
            List<Axis> axes = _showsService.GetAxes();

            ViewModel.Axes = axes;
        }

        private void LoadShow(string name)
        {
            Show show = _showsService.GetShow(name);

            SetShow(show);

            ReloadViews();
        }

        private void SetShow(Show show)
        {
            show.Cues.FillCues(ViewModel.Axes);
            if (show.Views == null)
            {
                show.Views = new ObservableCollection<View>();
            }
            show.Views.FillViews(ViewModel.Axes);

            show.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "SelectedView")
                {
                    show.SelectedView.IsSelected = true;
                }
            };

            ViewModel.CurrentShow = show;
        }

        //TODO: come up with the better approach than this one
        private void ReloadViews()
        {
            List<ViewsMenuItem> menuItems = new List<ViewsMenuItem>();

            //clear attached property
            if (ViewsContainer?.Collection != null)
            {
                foreach (MenuItem item in ViewsContainer.Collection)
                {
                    MenuItemExtensions.SetGroupName(item, null);
                }
            }

            foreach (View view in ViewModel.CurrentShow.Views)
            {
                ViewsMenuItem menuItem = new ViewsMenuItem
                {
                    Header = view.Name,
                    CommandParameter = view,
                    IsViewVisible = view.IsVisible,
                    OpenSettingsCommand = ViewCommands.Edit,
                    Style = (Style)FindResource("ViewsMenuSubmenuButton")
                };

                RoutedEventHandler checkedChanged = (sender, args) =>
                {
                    ViewModel.CurrentShow.SelectedView = view;
                };

                menuItem.Checked += checkedChanged;

                Binding viewVisibleBinding = new Binding("IsVisible");
                viewVisibleBinding.Source = view;
                viewVisibleBinding.Mode = BindingMode.TwoWay;

                menuItem.SetBinding(ViewsMenuItem.IsViewVisibleProperty, viewVisibleBinding);

                //menu item is only checkable when its view is visible
                Binding itemCheckableBinding = new Binding("IsVisible");
                itemCheckableBinding.Source = view;
                //itemCheckableBinding.Mode = BindingMode.TwoWay;

                menuItem.SetBinding(MenuItem.IsCheckableProperty, itemCheckableBinding);

                Binding itemCheckedBinding = new Binding("IsSelected");
                itemCheckedBinding.Source = view;
                itemCheckedBinding.Mode = BindingMode.TwoWay;

                menuItem.SetBinding(MenuItem.IsCheckedProperty, itemCheckedBinding);

                //adding mutually exclusive behavior
                MenuItemExtensions.SetGroupName(menuItem, "Views");

                menuItems.Add(menuItem);
            }

            ViewsContainer.Collection = menuItems;
        }

        private void OpenShow_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenShow_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ShowFile showFile = e.Parameter as ShowFile;
            if (showFile == null)
            {
                return;
            }

            LoadShow(showFile.Name);
        }

        private void ShowCommands_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ViewModel.CurrentShow != null;
        }

        private void IncreaseRevision_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (ViewModel.CurrentShow != null)
            {
                ConfirmationWindow confirmationWindow = new ConfirmationWindow
                {
                    Header = "Increasing revision#...",
                    Message = $"Are you sure, you want to increase revision for show '{ViewModel.CurrentShow.Name}' to rev# {ViewModel.CurrentShow.Revision+1}?",
                    Owner = this
                };

                bool? result = confirmationWindow.ShowDialog();

                if (result == true)
                {
                    Show show = _showsService.IncreaseShowRevision(ViewModel.CurrentShow);
                    LoadShow(show.Name);
                    ReloadShows();
                }
            }
        }

        private void SaveShow_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (ViewModel.CurrentShow != null)
            {
                Show savedShow = _showsService.SaveShow(ViewModel.CurrentShow);
                SetShow(savedShow);
            }
        }

        private void SaveShowAs_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (ViewModel.CurrentShow != null)
            {
                ItemNameWindow showNameWindow = new ItemNameWindow
                {
                    Header = "Save Show As...",
                    NewValue = ViewModel.CurrentShow.Name,
                    Owner = this
                };

                bool? result = showNameWindow.ShowDialog();

                if (result == true)
                {
                    if (string.IsNullOrEmpty(showNameWindow.NewValue))
                    {
                        MessageBoxWindow messageBox = new MessageBoxWindow
                        {
                            Header = "Show error",
                            Message = "Empty show name",
                            Owner = this,
                            Width = 400,
                            Height = 250
                        };

                        messageBox.ShowDialog();
                        return;
                    }

                    if (ViewModel.CurrentShow != null)
                    {
                        Show savedShow = _showsService.SaveShowAs(ViewModel.CurrentShow, showNameWindow.NewValue);
                        SetShow(savedShow);
                        ReloadShows();
                    }
                }
            }
        }

        private void DeleteShow_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ConfirmationWindow confirmationWindow = new ConfirmationWindow
            {
                Header = "Deleting show...",
                Message = $"Are you sure, you want to delete current show - '{ViewModel.CurrentShow.Name}' rev# {ViewModel.CurrentShow.Revision}?",
                Owner = this
            };

            bool? result = confirmationWindow.ShowDialog();

            if (result == true)
            {
                if (_showsService.DeleteShow(ViewModel.CurrentShow))
                {
                    ViewModel.CurrentShow = null;
                    ReloadShows();
                }
            }
        }

        private void OpenViewSettings_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenViewSettings_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            View view = e.Parameter as View;
            if (view != null)
            {
                EditViewWindow viewSettingsWindow = new EditViewWindow
                {
                    Header = "Edit View",
                    Owner = this,
                    View = view.Clone(),
                    Axes = new ObservableCollection<Axis>(ViewModel.Axes),
                    AllowsTransparency = true,
                    ExistingViews = ViewModel.CurrentShow.Views
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

                    if (view.IsSelected)
                    {
                        viewSettingsWindow.View.IsSelected = true;
                    }

                    ViewModel.CurrentShow.Views.Insert(ViewModel.CurrentShow.Views.IndexOf(view), viewSettingsWindow.View);
                    ViewModel.CurrentShow.Views.Remove(view);

                    ReloadViews();
                }
            }
        }

        private void WorkspaceContainer_OnCuesUpdated(object sender, CuesUpdatedEventArgs eventargs)
        {
            ViewModel.CurrentShow.Cues.FillCues(ViewModel.Axes);
        }

        private void WorkspaceContainer_OnProfilesUpdated(object sender, ProfilesUpdatedEventArgs eventargs)
        {
            ViewModel.CurrentShow.Cues.FillCues(ViewModel.Axes);
        }

        private void ViewsSettings_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            EditViewsWindow viewsSettingsWindow = new EditViewsWindow(ViewModel.CurrentShow.Views, ViewModel.Axes)
            {
                Owner = this
            };

            bool? result = viewsSettingsWindow.ShowDialog();
            if (result == true)
            {
                ViewModel.CurrentShow.Views = viewsSettingsWindow.Views;
                ReloadViews();
            }
        }

        private void ViewsSettings_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ViewModel?.CurrentShow?.Views != null;
        }
    }
}
