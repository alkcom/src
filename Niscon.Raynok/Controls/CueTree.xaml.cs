using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Niscon.Raynok.Extensions;
using Niscon.Raynok.Helpers;
using Niscon.Raynok.Models;
using Niscon.Raynok.Windows;

namespace Niscon.Raynok.Controls
{
    /// <summary>
    /// Interaction logic for Workspace.xaml
    /// </summary>
    public partial class CueTree : UserControl
    {
        private Cue _previousItem = null;

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

                if (SelectedNode.Type == CueType.Default)
                {
                    ManualMoveCue.Profiles = new ObservableCollection<Profile>(SelectedNode.Profiles);
                    _previousItem = SelectedNode;
                }
            };

            CueTreeView.ItemsChanged += (sender, args) =>
            {
                SelectFirstElement();
            };

            ManualMoveCue = new Cue
            {
                Name = "Manual Move Cue",
                Id = Guid.NewGuid(),
                Type = CueType.ManualMove
            };

            RecycleBinCue = new Cue
            {
                Name = "Recycle Bin Cue",
                Id = Guid.NewGuid(),
                Type = CueType.RecycleBin,
                Profiles = new ObservableCollection<Profile>(),
                Children = new ObservableCollection<Cue>()
            };

            SpecialNodes = new ObservableCollection<Cue>
            {
                ManualMoveCue,
                RecycleBinCue
            };
        }

        public event CuesUpdatedEventHandler CuesUpdated;

        public void SetManualMode(bool manualMode)
        {
            if (manualMode)
            {
                if (_previousItem == null)
                {
                    _previousItem = SelectedNode.Type == CueType.Default ? SelectedNode : Nodes.FirstOrDefault();
                }
                if (_previousItem != null)
                {
                    ManualMoveCue.Profiles = new ObservableCollection<Profile>(_previousItem.Profiles);
                    SelectedNode = ManualMoveCue;
                }
            }
            else
            {
                if (_previousItem == null)
                {
                    _previousItem = Nodes.FirstOrDefault();
                }
                if (_previousItem != null)
                {
                    SelectedNode = _previousItem;
                }
            }
        }

        private void SelectFirstElement()
        {
            try
            {
                TreeViewItem item = (TreeViewItem)CueTreeView.ItemContainerGenerator.ContainerFromItem(CueTreeView.Items[0]);
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

        private static readonly DependencyProperty SpecialNodesProperty = DependencyProperty.Register(
            "SpecialNodes", typeof(ObservableCollection<Cue>), typeof(CueTree), new PropertyMetadata(default(ObservableCollection<Cue>)));

        private ObservableCollection<Cue> SpecialNodes
        {
            get { return (ObservableCollection<Cue>) GetValue(SpecialNodesProperty); }
            set { SetValue(SpecialNodesProperty, value); }
        }

        public Cue ManualMoveCue { get; set; }
        public Cue RecycleBinCue { get; set; }

        private Cue CopiedCue { get; set; }

        private void ShowInvalidCueNameError(string value)
        {
            MessageBoxWindow messageBox = new MessageBoxWindow
            {
                Header = "Cue error",
                Message = $"Invalid cue name: {value}",
                Owner = Application.Current.MainWindow,
                Width = 400,
                Height = 250
            };

            messageBox.ShowDialog();
        }

        private void AddAfter_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Cue cue = e.Parameter as Cue;
            if (cue != null)
            {
                CuePropertiesWindow cuePropertiesWindow = new CuePropertiesWindow(new Cue
                {
                    Parent = cue.Parent,
                    Profiles = new ObservableCollection<Profile>(cue.Profiles),
                    Name = string.Empty
                }, Nodes)
                {
                    Owner = Application.Current.MainWindow,
                    Width = 500
                };

                bool? result = cuePropertiesWindow.ShowDialog();

                if (result == true)
                {
                    Cue newCue = cuePropertiesWindow.Cue;

                    newCue.Id = Guid.NewGuid();

                    if (newCue.Parent == null)
                    {
                        newCue.Type = CueType.Scene;
                    }

                    ObservableCollection<Cue> collection = cue.Parent == null ? Nodes : cue.Parent.Children;
                    collection.Insert(collection.IndexOf(cue) + 1, newCue);

                    OnCuesUpdated(new CuesUpdatedEventArgs(Nodes));
                }
            }
        }

        private void AddBefore_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Cue cue = e.Parameter as Cue;
            if (cue != null)
            {
                CuePropertiesWindow cuePropertiesWindow = new CuePropertiesWindow(new Cue
                {
                    Parent = cue.Parent,
                    Profiles = new ObservableCollection<Profile>(cue.Profiles),
                    Name = string.Empty
                }, Nodes)
                {
                    Owner = Application.Current.MainWindow,
                    Width = 500
                };

                bool? result = cuePropertiesWindow.ShowDialog();

                if (result == true)
                {
                    Cue newCue = cuePropertiesWindow.Cue;

                    newCue.Id = Guid.NewGuid();

                    if (newCue.Parent == null)
                    {
                        newCue.Type = CueType.Scene;
                    }
                    ObservableCollection<Cue> collection = cue.Parent == null ? Nodes : cue.Parent.Children;
                    collection.Insert(collection.IndexOf(cue), newCue);

                    OnCuesUpdated(new CuesUpdatedEventArgs(Nodes));
                }
            }
        }

        private void CueCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            Cue cue = e.Parameter as Cue;
            e.CanExecute = cue != null && cue.Type == CueType.Default;
        }

        private void Delete_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Cue cue = e.Parameter as Cue;
            if (cue != null)
            {
                ConfirmationWindow confirmationWindow = new ConfirmationWindow
                {
                    Header = $"Deleting {cue.Type}...",
                    Message = $"Are you sure, you want to delete {cue.Type} '{cue.Name}'?",
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

                    cue.Parent = RecycleBinCue;
                    RecycleBinCue.Children.Add(cue);

                    OnCuesUpdated(new CuesUpdatedEventArgs(Nodes));
                }
            }
        }

        private void CueProperties_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Cue cue = e.Parameter as Cue;
            if (cue != null)
            {
                CuePropertiesWindow cuePropertiesWindow = new CuePropertiesWindow(cue.Clone(), Nodes)
                {
                    Owner = Application.Current.MainWindow
                };

                bool? result = cuePropertiesWindow.ShowDialog();
                if (result == true)
                {
                    if (string.IsNullOrEmpty(cuePropertiesWindow.Cue.Name))
                    {
                        ShowInvalidCueNameError(cuePropertiesWindow.Cue.Name);
                        return;
                    }

                    cue.Name = cuePropertiesWindow.Cue.Name;
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
                    AutofollowNode = cue,
                    Nodes = Nodes
                };

                bool? result = makeCueAutofollowWindow.ShowDialog();
                if (result == true)
                {
                    Cue newParent = makeCueAutofollowWindow.SelectedNode;

                    if (newParent == null)
                    {
                        MessageBoxWindow messageBox = new MessageBoxWindow
                        {
                            Header = "Cue error",
                            Message = $"You did not select a cue",
                            Owner = Application.Current.MainWindow,
                            Width = 400,
                            Height = 250
                        };

                        messageBox.ShowDialog();
                        return;
                    }

                    if (cue.Parent != null)
                    {
                        cue.Parent.Children.Remove(cue);
                    }
                    else
                    {
                        Nodes.Remove(cue);
                    }

                    if (newParent.Children == null)
                    {
                        newParent.Children = new ObservableCollection<Cue>();
                    }

                    newParent.Children.Add(cue);
                    cue.Parent = newParent;

                    OnCuesUpdated(new CuesUpdatedEventArgs(Nodes));
                }
            }
        }

        private void AddAutofollow_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Cue cue = e.Parameter as Cue;
            if (cue != null)
            {
                string name;
                if (cue.Children?.Any() == true)
                {
                    string lastName = cue.Children.Last().Name;
                    string[] parts = lastName.Split(' ');
                    int index;
                    if (!int.TryParse(parts.Last(), out index))
                    {
                        index = 0;
                    }

                    name = $"{cue.Name} {index + 1}";
                }
                else
                {
                    name = $"{cue.Name} 1";
                }

                CuePropertiesWindow cuePropertiesWindow = new CuePropertiesWindow(new Cue
                {
                    Parent = cue,
                    Profiles = new ObservableCollection<Profile>(cue.Profiles),
                    Name = name
                }, Nodes)
                {
                    Owner = Application.Current.MainWindow,
                    Width = 400
                };

                bool? result = cuePropertiesWindow.ShowDialog();

                if (result == true)
                {
                    Cue newCue = cuePropertiesWindow.Cue;

                    newCue.Id = Guid.NewGuid();

                    if (cue.Children == null)
                    {
                        cue.Children = new ObservableCollection<Cue>();
                    }

                    cue.Children.Add(newCue);

                    OnCuesUpdated(new CuesUpdatedEventArgs(Nodes));
                }
            }
        }

        private void MoveUp_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            Cue cue = e.Parameter as Cue;
            if (cue != null)
            {
                ObservableCollection<Cue> collection = cue.Parent == null ? Nodes : cue.Parent.Children;

                e.CanExecute = collection.IndexOf(cue) > 0;
            }
        }

        private void MoveDown_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            Cue cue = e.Parameter as Cue;
            if (cue != null)
            {
                ObservableCollection<Cue> collection = cue.Parent == null ? Nodes : cue.Parent.Children;

                e.CanExecute = collection.IndexOf(cue) < collection.Count - 1;
            }
        }

        private void MoveUp_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Cue cue = e.Parameter as Cue;
            if (cue != null)
            {
                ObservableCollection<Cue> collection = cue.Parent == null ? Nodes : cue.Parent.Children;
                int oldIndex = collection.IndexOf(cue);

                collection.Remove(cue);
                collection.Insert(oldIndex - 1, cue);

                OnCuesUpdated(new CuesUpdatedEventArgs(Nodes));
            }
        }

        private void MoveDown_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Cue cue = e.Parameter as Cue;
            if (cue != null)
            {
                ObservableCollection<Cue> collection = cue.Parent == null ? Nodes : cue.Parent.Children;
                int oldIndex = collection.IndexOf(cue);

                collection.Remove(cue);
                collection.Insert(oldIndex + 1, cue);

                OnCuesUpdated(new CuesUpdatedEventArgs(Nodes));
            }
        }

        private void Copy_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            Cue cue = e.Parameter as Cue;
            if (cue != null)
            {
                e.CanExecute = cue.Type == CueType.Default;
            }
        }

        private void Copy_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Cue cue = e.Parameter as Cue;
            if (cue != null)
            {
                CopiedCue = cue;
            }
        }

        private void Paste_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            Cue cue = e.Parameter as Cue;
            if (cue != null)
            {
                e.CanExecute = CopiedCue != null && cue.Type == CueType.Default;
            }
        }

        private void Paste_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Cue cue = e.Parameter as Cue;
            if (cue != null && CopiedCue != null)
            {
                ObservableCollection<Cue> copiedCueCollection = CopiedCue.Parent == null ? Nodes : CopiedCue.Parent.Children;
                ObservableCollection<Cue> pastedCueCollection = cue.Parent == null ? Nodes : cue.Parent.Children;

                copiedCueCollection.Remove(CopiedCue);
                pastedCueCollection.Insert(pastedCueCollection.IndexOf(cue)+1, CopiedCue);

                CopiedCue = null;

                OnCuesUpdated(new CuesUpdatedEventArgs(Nodes));
            }
        }

        protected virtual void OnCuesUpdated(CuesUpdatedEventArgs eventargs)
        {
            CuesUpdated?.Invoke(this, eventargs);
        }

        private void SceneCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            Cue cue = e.Parameter as Cue;
            e.CanExecute = cue != null && cue.Type == CueType.Scene;
        }

        private void DeleteScene_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            
        }

        private void PasteScene_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            Cue scene = e.Parameter as Cue;
            if (scene != null)
            {
                e.CanExecute = CopiedCue != null && scene.Type == CueType.Scene;
            }
        }
    }
}
