using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Niscon.Raynok.Commands
{
    public static class SceneCommands
    {
        public static readonly RoutedUICommand AddBefore = new RoutedUICommand("Add scene before", "AddCueBefore", typeof(FrameworkElement));
        public static readonly RoutedUICommand AddAfter = new RoutedUICommand("Add scene after", "AddCueAfter", typeof(FrameworkElement));
        public static readonly RoutedUICommand Delete = new RoutedUICommand("Delete scene", "DeleteCue", typeof(FrameworkElement));
        public static readonly RoutedUICommand MoveUp = new RoutedUICommand("Move scene up", "MoveCueUp", typeof(FrameworkElement));
        public static readonly RoutedUICommand MoveDown = new RoutedUICommand("Move scene down", "MoveCueDown", typeof(FrameworkElement));
        public static readonly RoutedUICommand Copy = new RoutedUICommand("Copy scene", "CopyCue", typeof(FrameworkElement));
        public static readonly RoutedUICommand Paste = new RoutedUICommand("Paste scene", "PasteCue", typeof(FrameworkElement));
        public static readonly RoutedUICommand EmptyRecycleBin = new RoutedUICommand("Empty Recycle Bin", "EmptyRecycleBin", typeof(FrameworkElement));
        public static readonly RoutedUICommand AddCue = new RoutedUICommand("Add Cue", "AddCue", typeof(FrameworkElement));
    }
}
