using System.Windows;
using System.Windows.Input;

namespace Niscon.Raynok.Commands
{
    public static class ShowCommands
    {
        public static readonly RoutedUICommand New = new RoutedUICommand("Create new show", "NewShow", typeof(FrameworkElement));
        public static readonly RoutedUICommand Open = new RoutedUICommand("Open existing show", "OpenShow", typeof(FrameworkElement));
        public static readonly RoutedUICommand Save = new RoutedUICommand("Save show", "SaveShow", typeof(FrameworkElement));
        public static readonly RoutedUICommand SaveAs = new RoutedUICommand("Save show as", "SaveShowAs", typeof(FrameworkElement));
        public static readonly RoutedUICommand IncreaseRevision = new RoutedUICommand("Increase show revision", "IncreaseShowRevision", typeof(FrameworkElement));
        public static readonly RoutedUICommand Delete = new RoutedUICommand("Delete show", "DeleteShow", typeof(FrameworkElement));
    }
}
