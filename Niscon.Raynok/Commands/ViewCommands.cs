using System.Windows;
using System.Windows.Input;

namespace Niscon.Raynok.Commands
{
    public static class ViewCommands
    {
        public static readonly RoutedUICommand New = new RoutedUICommand("Create new view", "NewView", typeof(FrameworkElement));
        public static readonly RoutedUICommand Delete = new RoutedUICommand("Delete view", "DeleteView", typeof(FrameworkElement));
        public static readonly RoutedUICommand Select = new RoutedUICommand("Select view", "SelectView", typeof(FrameworkElement));
        public static readonly RoutedUICommand Edit = new RoutedUICommand("Edit View", "EditView", typeof(FrameworkElement));
        public static readonly RoutedUICommand AddAxis = new RoutedUICommand("Add axis to view", "AddViewAxis", typeof(FrameworkElement));
        public static readonly RoutedUICommand RemoveAxis = new RoutedUICommand("Remove axis from view", "RemoveViewAxis", typeof(FrameworkElement));
        public static readonly RoutedUICommand ResetChanges = new RoutedUICommand("Reset view settings changes", "ResetViewsChanges", typeof(FrameworkElement));
        public static readonly RoutedUICommand MoveUp = new RoutedUICommand("Move View Up", "MoveViewUp", typeof(FrameworkElement));
        public static readonly RoutedUICommand MoveDown = new RoutedUICommand("Move View Down", "MoveViewDown", typeof(FrameworkElement));
        public static readonly RoutedUICommand Settings = new RoutedUICommand("Open Views Settings", "OpenViewsSettings", typeof(FrameworkElement));

    }
}
