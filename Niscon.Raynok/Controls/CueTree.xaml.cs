using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Niscon.Raynok.Models;
using Niscon.Raynok.Windows;

namespace Niscon.Raynok.Controls
{
    /// <summary>
    /// Interaction logic for Workspace.xaml
    /// </summary>
    public partial class CueTree : UserControl
    {
        public CueTree()
        {
            InitializeComponent();

            CueTreeView.Loaded += (sender, args) =>
            {
                SelectFirstElement();
            };

            CueTreeView.SelectedItemChanged += (sender, args) =>
            {
                if (args.NewValue == null)
                {
                    SelectFirstElement();
                }
            };

            CueTreeView.ItemsChanged += (sender, args) =>
            {
                SelectFirstElement();
            };
        }

        private void SelectFirstElement()
        {
            try
            {
                TreeViewItem item = (TreeViewItem)CueTreeView.ItemContainerGenerator.ContainerFromItem(CueTreeView.Items[1]);
                if (item == null)
                {
                    return;
                }
                item.IsSelected = true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public static readonly DependencyProperty NodesProperty = DependencyProperty.Register(
            "Nodes", typeof(ObservableCollection<Cue>), typeof(CueTree), new PropertyMetadata(default(ObservableCollection<Cue>)));

        public ObservableCollection<Cue> Nodes
        {
            get { return (ObservableCollection<Cue>) GetValue(NodesProperty); }
            set { SetValue(NodesProperty, value); }
        }

        public static readonly DependencyProperty SelectedNodeProperty = DependencyProperty.Register(
            "SelectedNode", typeof(Cue), typeof(CueTree), new PropertyMetadata(default(Cue)));

        public Cue SelectedNode
        {
            get { return (Cue) GetValue(SelectedNodeProperty); }
            set { SetValue(SelectedNodeProperty, value); }
        }

        private void AddAfter_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Cue cue = e.Parameter as Cue;
            if (cue != null)
            {
                ItemNameWindow cueNameWindow = new ItemNameWindow
                {
                    Header = $"Add New Cue After {cue.Name}...",
                    NewValue = "",
                    Owner = Application.Current.MainWindow,
                    Width = 400
                };

                bool? result = cueNameWindow.ShowDialog();

                if (result == true)
                {
                    string fixedValue = cueNameWindow.NewValue.Replace("_", string.Empty).Replace("-", string.Empty);
                    if (string.IsNullOrEmpty(fixedValue))
                    {
                        MessageBox.Show($"Invalid cue name: {fixedValue}");
                        return;
                    }

                    Cue newCue = new Cue
                    {
                        Id = Guid.NewGuid(),
                        Name = fixedValue,
                        Profiles = new ObservableCollection<Profile>(cue.Profiles)
                    };

                    if (cue.Parent == null)
                    {
                        Nodes.Insert(Nodes.IndexOf(cue)+1, newCue);
                    }
                    else
                    {
                        newCue.Parent = cue.Parent;
                        cue.Parent.Children.Insert(cue.Parent.Children.IndexOf(cue)+1, newCue);
                    }
                }
            }
        }

        private void AddBefore_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Cue cue = e.Parameter as Cue;
            if (cue != null)
            {
                ItemNameWindow cueNameWindow = new ItemNameWindow
                {
                    Header = $"Add New Cue Before {cue.Name}...",
                    NewValue = "",
                    Owner = Application.Current.MainWindow,
                    Width = 400
                };

                bool? result = cueNameWindow.ShowDialog();

                if (result == true)
                {
                    string fixedValue = cueNameWindow.NewValue.Replace("_", string.Empty).Replace("-", string.Empty);
                    if (string.IsNullOrEmpty(fixedValue))
                    {
                        MessageBox.Show($"Invalid cue name: {fixedValue}");
                        return;
                    }

                    Cue newCue = new Cue
                    {
                        Id = Guid.NewGuid(),
                        Name = fixedValue,
                        Profiles = new ObservableCollection<Profile>(cue.Profiles)
                    };

                    if (cue.Parent == null)
                    {
                        Nodes.Insert(Nodes.IndexOf(cue), newCue);
                    }
                    else
                    {
                        newCue.Parent = cue.Parent;
                        cue.Parent.Children.Insert(cue.Parent.Children.IndexOf(cue), newCue);
                    }
                }
            }
        }

        private void CueCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            Cue cue = e.Parameter as Cue;
            e.CanExecute = cue != null;
        }

        private void Delete_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Cue cue = e.Parameter as Cue;
            if (cue != null)
            {
                ConfirmationWindow confirmationWindow = new ConfirmationWindow
                {
                    Header = "Deleting Cue...",
                    Message = $"Are you sure, you want to delete cue '{cue.Name}'?",
                    Owner = Application.Current.MainWindow
                };

                bool? result = confirmationWindow.ShowDialog();

                if (result == true)
                {
                    if (cue.Parent == null)
                    {
                        Nodes.Remove(cue);
                    }
                    else
                    {
                        cue.Parent.Children.Remove(cue);
                    }
                }
            }
        }

        private void Rename_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Cue cue = e.Parameter as Cue;
            if (cue != null)
            {
                ItemNameWindow cueNameWindow = new ItemNameWindow
                {
                    Header = "Cue Properties...",
                    NewValue = cue.Name,
                    Owner = Application.Current.MainWindow
                };

                bool? result = cueNameWindow.ShowDialog();

                if (result == true)
                {
                    string fixedValue = cueNameWindow.NewValue.Replace("_", string.Empty).Replace("-", string.Empty);
                    if (string.IsNullOrEmpty(fixedValue))
                    {
                        MessageBox.Show($"Invalid cue name: {fixedValue}");
                        return;
                    }

                    cue.Name = fixedValue;
                }
            }
        }

        private void MakeAutofollow_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Cue cue = e.Parameter as Cue;
            if (cue != null)
            {
                MakeCueAutofollowWindow makeCueAutofollowWindow = new MakeCueAutofollowWindow
                {
                    Owner = Application.Current.MainWindow,
                    Nodes = Nodes,
                    SelectedNode = cue
                };

                bool? result = makeCueAutofollowWindow.ShowDialog();
                if (result == true)
                {
                    Cue parent = makeCueAutofollowWindow.SelectedNode;

                    if (parent == null)
                    {
                        MessageBox.Show("You did not select a cue!");
                        return;
                    }

                    Cue newCue = new Cue
                    {
                        Id = Guid.NewGuid(),
                        Name = makeCueAutofollowWindow.CueName,
                        Profiles = new ObservableCollection<Profile>(cue.Profiles),
                        Parent = parent
                    };

                    if (parent.Children == null)
                    {
                        parent.Children = new ObservableCollection<Cue>();
                    }

                    parent.Children.Add(newCue);
                }

                //ItemNameWindow cueNameWindow = new ItemNameWindow
                //{
                //    Header = $"Make Autofollow for Cue '{cue.Name}'...",
                //    NewValue = "",
                //    Owner = Application.Current.MainWindow,
                //    Width = 400
                //};

                //bool? result = cueNameWindow.ShowDialog();

                //if (result == true)
                //{
                //    string fixedValue = cueNameWindow.NewValue.Replace("_", string.Empty).Replace("-", string.Empty);
                //    if (string.IsNullOrEmpty(fixedValue))
                //    {
                //        MessageBox.Show($"Invalid cue name: {fixedValue}");
                //        return;
                //    }

                //    Cue newCue = new Cue
                //    {
                //        Id = Guid.NewGuid(),
                //        Name = fixedValue,
                //        Profiles = new ObservableCollection<Profile>(cue.Profiles),
                //        Parent = cue
                //    };

                //    if (cue.Children == null)
                //    {
                //        cue.Children = new ObservableCollection<Cue>();
                //    }

                //    cue.Children.Add(newCue);
                //}
            }
        }
    }
}
