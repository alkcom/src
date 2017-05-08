using System.Windows;
using System.Windows.Input;

namespace Niscon.Raynok.Commands
{
    public static class ViewCommands
    {
        public static readonly RoutedUICommand New = new RoutedUICommand("Create new view", "NewView", typeof(FrameworkElement));
        public static readonly RoutedUICommand Delete = new RoutedUICommand("Delete view", "DeleteView", typeof(FrameworkElement));
        public static readonly RoutedUICommand Select = new RoutedUICommand("Select view", "SelectView", typeof(FrameworkElement));
        public static readonly RoutedUICommand OpenSettings = new RoutedUICommand("Open settings", "OpenViewSettings", typeof(FrameworkElement));
        public static readonly RoutedUICommand AddAxis = new RoutedUICommand("Add axis to view", "AddViewAxis", typeof(FrameworkElement));
        public static readonly RoutedUICommand RemoveAxis = new RoutedUICommand("Remove axis from view", "RemoveViewAxis", typeof(FrameworkElement));
    }
}
