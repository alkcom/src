using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace Niscon.Raynok.Helpers
{
    public class ExtendedTreeView : TreeView
    {
        public ExtendedTreeView()
            : base()
        {
            this.SelectedItemChanged += SelectedItemChanged_Internal;
        }

        public event NotifyCollectionChangedEventHandler ItemsChanged;

        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);

            ItemsChanged?.Invoke(this, e);
        }

        private void SelectedItemChanged_Internal(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (SelectedItem != null)
            {
                SetValue(SelectedItem_Property, SelectedItem);
            }
        }

        public object SelectedItem_
        {
            get { return (object)GetValue(SelectedItem_Property); }
            set { SetValue(SelectedItem_Property, value); }
        }

        public static readonly DependencyProperty SelectedItem_Property = DependencyProperty.Register("SelectedItem_", typeof(object), typeof(ExtendedTreeView), new UIPropertyMetadata(null,
            (o, args) =>
            {
                //workaround, because SelectedItemProperty is read only and can't be changed
                //now only works down 2 levels, because we do not have more
                ExtendedTreeView treeView = (ExtendedTreeView) o;

                TreeViewItem item = (TreeViewItem)treeView.ItemContainerGenerator.ContainerFromItem(treeView.SelectedItem_);
                if (item != null)
                {
                    item.IsSelected = true;
                }
                else
                {
                    foreach (object containerItem in treeView.ItemContainerGenerator.Items)
                    {
                        TreeViewItem container =
                            (TreeViewItem) treeView.ItemContainerGenerator.ContainerFromItem(containerItem);
                        item = (TreeViewItem)container.ItemContainerGenerator.ContainerFromItem(treeView.SelectedItem_);
                        if (item != null)
                        {
                            item.IsSelected = true;
                            break;
                        }
                    }
                }
            }));
    }
}
