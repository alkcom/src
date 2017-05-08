using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Niscon.Raynok.Converters;
using Niscon.Raynok.Helpers;
using Niscon.Raynok.Models;
using Niscon.Raynok.ViewModels;
using SharpGL.SceneGraph;
using SharpGL.WPF;

namespace Niscon.Raynok.Controls
{
    public enum WorkspaceState
    {
        None,
        Grid,
        Presets,
        Ratios,
        _3D
    }

    /// <summary>
    /// Interaction logic for WorkspaceContainer.xaml
    /// </summary>
    public partial class WorkspaceContainer : UserControl
    {
        private Cue _previousItem = null;

        public WorkspaceContainer()
        {
            InitializeComponent();

            DependencyPropertyDescriptor isManualModeDescriptor = DependencyPropertyDescriptor.FromProperty(IsManualModeProperty, typeof(WorkspaceContainer));
            isManualModeDescriptor.AddValueChanged(this, (sender, args) =>
            {
                if (IsManualMode && !SelectedNode.Equals(CurrentShow.Cues.First()))
                {
                    _previousItem = CueTree.SelectedNode;
                    CueTree.Nodes.First().Profiles = CueTree.SelectedNode.Profiles;

                    CueTree.SelectedNode = CurrentShow.Cues.FirstOrDefault();
                }
                else if (!IsManualMode && SelectedNode.Equals(CurrentShow.Cues.First()))
                {
                    CueTree.SelectedNode = _previousItem;
                    //CueTree.Nodes.First().Profiles = _previousItem.Profiles;
                    //_previousItem = null;
                }
            });

            DependencyPropertyDescriptor cueTreeSelectedValueDescriptor = DependencyPropertyDescriptor.FromProperty(Controls.CueTree.SelectedNodeProperty, typeof(CueTree));
            cueTreeSelectedValueDescriptor.AddValueChanged(CueTree, (sender, args) =>
            {
                if (SelectedNode == null || CurrentShow.Cues == null || !CurrentShow.Cues.Any())
                {
                    return;
                }

                if (SelectedNode.Equals(CurrentShow.Cues.First()))
                {
                    IsManualMode = true;
                }
                else
                {
                    IsManualMode = false;
                    _previousItem = SelectedNode;
                    CurrentShow.Cues.First().Profiles = SelectedNode.Profiles;
                }
            });
        }

        //private void NextCueButton_Click(object sender, RoutedEventArgs e)
        //{
        //    int idx = Workspace.Nodes.IndexOf(SelectedNode) + 1;
        //    if (idx < Workspace.Nodes.Count)
        //    {
        //        SelectedNode = Workspace.Nodes.ElementAtOrDefault(idx);
        //    }
        //}

        //private void PreviousCueButton_Click(object sender, RoutedEventArgs e)
        //{
        //    int idx = Workspace.Nodes.IndexOf(SelectedNode) - 1;
        //    if (idx > 0)
        //    {
        //        SelectedNode = Workspace.Nodes.ElementAtOrDefault(idx);
        //    }
        //}

        //private void FirstCueButton_Click(object sender, RoutedEventArgs e)
        //{
        //    SelectedNode = Workspace.Nodes.ElementAtOrDefault(1);
        //}

        //private void LastCueButton_Click(object sender, RoutedEventArgs e)
        //{
        //    SelectedNode = Workspace.Nodes.LastOrDefault();
        //}

        //public static readonly DependencyProperty StateProperty = DependencyProperty.Register(
        //    "State", typeof(WorkspaceState?), typeof(WorkspaceContainer), new PropertyMetadata(default(WorkspaceState?)));

        //public WorkspaceState? State
        //{
        //    get { return (WorkspaceState) GetValue(StateProperty); }
        //    set { SetValue(StateProperty, value); }
        //}

        //public static readonly DependencyProperty WorkspaceProperty = DependencyProperty.Register(
        //    "Workspace", typeof(WorkspaceViewModel), typeof(WorkspaceContainer), new PropertyMetadata(default(WorkspaceViewModel)));

        //public WorkspaceViewModel Workspace
        //{
        //    get { return (WorkspaceViewModel) GetValue(WorkspaceProperty); }
        //    set { SetValue(WorkspaceProperty, value); }
        //}

        public static readonly DependencyProperty SelectedViewProperty = DependencyProperty.Register(
            "SelectedView", typeof(View), typeof(WorkspaceContainer), new PropertyMetadata(default(View)));

        public View SelectedView
        {
            get { return (View) GetValue(SelectedViewProperty); }
            set { SetValue(SelectedViewProperty, value); }
        }


        public static readonly DependencyProperty SelectedNodeProperty = DependencyProperty.Register(
            "SelectedNode", typeof(Cue), typeof(WorkspaceContainer), new PropertyMetadata(default(Cue)));

        public Cue SelectedNode
        {
            get { return (Cue) GetValue(SelectedNodeProperty); }
            set { SetValue(SelectedNodeProperty, value); }
        }

        public static readonly DependencyProperty AppSettingsProperty = DependencyProperty.Register(
            "AppSettings", typeof(AppSettings), typeof(WorkspaceContainer), new PropertyMetadata(default(AppSettings)));

        public AppSettings AppSettings
        {
            get { return (AppSettings) GetValue(AppSettingsProperty); }
            set { SetValue(AppSettingsProperty, value); }
        }



        public static readonly DependencyProperty IsCueTreeVisibleProperty = DependencyProperty.Register(
            "IsCueTreeVisible", typeof(bool), typeof(WorkspaceContainer), new PropertyMetadata(default(bool)));

        public bool IsCueTreeVisible
        {
            get { return (bool) GetValue(IsCueTreeVisibleProperty); }
            set { SetValue(IsCueTreeVisibleProperty, value); }
        }

        public static readonly DependencyProperty IsManualModeProperty = DependencyProperty.Register(
            "IsManualMode", typeof(bool), typeof(WorkspaceContainer), new PropertyMetadata(default(bool)));

        public bool IsManualMode
        {
            get { return (bool) GetValue(IsManualModeProperty); }
            set { SetValue(IsManualModeProperty, value); }
        }

        public static readonly DependencyProperty CurrentShowProperty = DependencyProperty.Register(
            "CurrentShow", typeof(Show), typeof(WorkspaceContainer), new PropertyMetadata(default(Show), CurrentShowChanged));

        private static void CurrentShowChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            Show show = eventArgs.NewValue as Show;
            Show oldShow = eventArgs.OldValue as Show;
            WorkspaceContainer container = dependencyObject as WorkspaceContainer;

            if (oldShow?.Views != null && container != null)
            {
                oldShow.Views.CollectionChanged -= container.ViewsOnCollectionChanged;
                container.AxesWorkspaces.Children.RemoveRange(0, container.AxesWorkspaces.Children.Count);
            }

            if (show?.Views != null && container != null)
            {
                show.Views.CollectionChanged += container.ViewsOnCollectionChanged;
                container.AddViews(show.Views);
            }
        }

        private void ViewsOnCollectionChanged(object o, NotifyCollectionChangedEventArgs eventArgs)
        {
            switch (eventArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    AddViews(eventArgs.NewItems.Cast<View>().ToList(), eventArgs.NewStartingIndex);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    RemoveViews(eventArgs.OldItems.Cast<View>().ToList(), eventArgs.OldStartingIndex);
                    break;
            }
        }

        private void AddViews(IList<View> views, int? startIndex = null)
        {
            foreach (View view in views)
            {
                int newColumnIndex = AxesWorkspaces.ColumnDefinitions.Count;
                AxesWorkspaces.ColumnDefinitions.Add(new ColumnDefinition());

                Binding widthBinding = new Binding
                {
                    ElementName = "SizingGrid",
                    Path = new PropertyPath("ActualWidth")
                };

                Binding appSettingsBinding = new Binding("AppSettings");

                //Binding profilesBinding = new Binding("SelectedNode.Profiles");
                MultiBinding profilesBinding = new MultiBinding();
                profilesBinding.Converter = new AxesProfilesMatchingConverter();
                profilesBinding.Bindings.Add(new Binding("SelectedNode.Profiles"));
                profilesBinding.Bindings.Add(new Binding("Axes")
                {
                    Source = view
                });

                Binding visibilityBinding = new Binding("IsVisible")
                {
                    Source = view,
                    Converter = new BooleanToVisibilityConverter()
                };

                FrameworkElement element;

                switch (view.Type)
                {
                    case ViewType.CueInfo:
                        element = new AxesGrid();
                        
                        element.SetBinding(AxesGrid.AppSettingsProperty, appSettingsBinding);
                        element.SetBinding(AxesDisplayControl.ProfilesProperty, profilesBinding);
                        break;
                    case ViewType.Preset:
                        element = new AxesPresets();

                        element.SetBinding(AxesPresets.AppSettingsProperty, appSettingsBinding);
                        element.SetBinding(AxesDisplayControl.ProfilesProperty, profilesBinding);
                        break;
                    case ViewType.Section:
                        element = new AxesColumns();

                        element.SetBinding(AxesColumns.AppSettingsProperty, appSettingsBinding);
                        element.SetBinding(AxesDisplayControl.ProfilesProperty, profilesBinding);
                        break;
                    case ViewType._3D:
                        element = new OpenGLControl();
                        break;
                    default:
                        throw new Exception("Unknown view type");
                }

                Grid.SetColumn(element, newColumnIndex);
                element.SetBinding(VisibilityProperty, visibilityBinding);
                element.SetBinding(WidthProperty, widthBinding);
                FluidItemScroller.SetItemValue(element, view);
                element.Margin = new Thickness(40, 0, 40, 0);

                if (startIndex.HasValue)
                {
                    AxesWorkspaces.Children.Insert(startIndex.Value, element);
                }
                else
                {
                    AxesWorkspaces.Children.Add(element);
                }
            }
        }

        private void RemoveViews(IList<View> views, int startIndex)
        {
            foreach (View view in views)
            {
                AxesWorkspaces.Children.RemoveAt(startIndex);
            }
        }

        public Show CurrentShow
        {
            get { return (Show) GetValue(CurrentShowProperty); }
            set { SetValue(CurrentShowProperty, value); }
        }




        private void OpenGLControl_OnOpenGLDraw(object sender, OpenGLEventArgs args)
        {
            
        }

        private void OpenGLControl_OnOpenGLInitialized(object sender, OpenGLEventArgs args)
        {
            
        }

        private void OpenGLControl_OnResized(object sender, OpenGLEventArgs args)
        {
            
        }

        //replace for mouse down
        private void UIElement_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {


            //required, so the event will not bubble up to parent controls
            e.Handled = true;
        }

        private void UIElement_OnPreviewMouseMove(object sender, MouseEventArgs e)
        {


            //required, so the event will not bubble up to parent controls
            e.Handled = true;
        }

        private void AxesGrid_OnCurrentValueDialogRequested(object sender, CurrentValueDialogRequestedEventArgs eventargs)
        {
            CurrentValueDialog.Axis = eventargs.Axis;

            CurrentValueDialog.Show();
        }
    }
}
