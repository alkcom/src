using System.Windows;
using System.Windows.Input;

namespace Niscon.Raynok.Commands
{
    public static class CueCommands
    {
        public static readonly RoutedUICommand AddBefore = new RoutedUICommand("Add cue before", "AddCueBefore", typeof(FrameworkElement));
        public static readonly RoutedUICommand AddAfter = new RoutedUICommand("Add cue after", "AddCueAfter", typeof(FrameworkElement));
        public static readonly RoutedUICommand MakeAutofollow = new RoutedUICommand("Make cue an autofollow of another cue", "MakeCueAutofollow", typeof(FrameworkElement));
        public static readonly RoutedUICommand AddAutofollow = new RoutedUICommand("Add autofollow for cue", "AddCueAutofollow", typeof(FrameworkElement));
        public static readonly RoutedUICommand Delete = new RoutedUICommand("Delete cue", "DeleteCue", typeof(FrameworkElement));
        public static readonly RoutedUICommand Rename = new RoutedUICommand("Rename cue", "RenameCue", typeof(FrameworkElement));
        public static readonly RoutedUICommand MoveUp = new RoutedUICommand("Move cue up", "MoveCueUp", typeof(FrameworkElement));
        public static readonly RoutedUICommand MoveDown = new RoutedUICommand("Move cue down", "MoveCueDown", typeof(FrameworkElement));
        public static readonly RoutedUICommand Copy = new RoutedUICommand("Copy cue", "CopyCue", typeof(FrameworkElement));
        public static readonly RoutedUICommand Paste = new RoutedUICommand("Paste cue", "PasteCue", typeof(FrameworkElement));
        public static readonly RoutedUICommand AfParameters = new RoutedUICommand("Open AF Parameters", "CueAfParameters", typeof(FrameworkElement));
        public static readonly RoutedUICommand CueProperties = new RoutedUICommand("Open Cue Properties", "CueProperties", typeof(FrameworkElement));
    }
}
