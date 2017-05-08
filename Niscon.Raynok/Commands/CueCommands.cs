using System.Windows;
using System.Windows.Input;

namespace Niscon.Raynok.Commands
{
    public static class CueCommands
    {
        public static readonly RoutedUICommand AddBefore = new RoutedUICommand("Add cue before", "AddCueBefore", typeof(FrameworkElement));
        public static readonly RoutedUICommand AddAfter = new RoutedUICommand("Add cue after", "AddCueAfter", typeof(FrameworkElement));
        public static readonly RoutedUICommand MakeAutofollow = new RoutedUICommand("Make autofollow for cue", "MakeCueAutofollow", typeof(FrameworkElement));
        public static readonly RoutedUICommand Delete = new RoutedUICommand("Delete cue", "DeleteCue", typeof(FrameworkElement));
        public static readonly RoutedUICommand Rename = new RoutedUICommand("Rename cue", "RenameCue", typeof(FrameworkElement));
    }
}
