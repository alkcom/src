using System.Windows;
using System.Windows.Input;

namespace Niscon.Raynok.Commands
{
    public class AppCommands
    {
        public static readonly RoutedUICommand Close = new RoutedUICommand("Close application", "CloseApplication", typeof(FrameworkElement));
        public static readonly RoutedUICommand CloseWindow = new RoutedUICommand("Close current window", "CloseWindow", typeof(FrameworkElement));
        public static readonly RoutedUICommand Ok = new RoutedUICommand("Confirm action", "Ok", typeof(FrameworkElement));
        public static readonly RoutedUICommand Cancel = new RoutedUICommand("Cancel changes", "Cancel", typeof(FrameworkElement));
    }
}
