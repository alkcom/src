using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Niscon.Raynok.Controls
{
    public class ViewsMenuItem : MenuItem
    {
        public static readonly DependencyProperty IsViewVisibleProperty = DependencyProperty.Register(
            "IsViewVisible", typeof(bool), typeof(ViewsMenuItem), new PropertyMetadata(default(bool)));

        public bool IsViewVisible
        {
            get { return (bool) GetValue(IsViewVisibleProperty); }
            set { SetValue(IsViewVisibleProperty, value); }
        }

        public static readonly DependencyProperty OpenSettingsCommandProperty = DependencyProperty.Register(
            "OpenSettingsCommand", typeof(RoutedUICommand), typeof(ViewsMenuItem), new PropertyMetadata(default(RoutedUICommand)));

        public RoutedUICommand OpenSettingsCommand
        {
            get { return (RoutedUICommand) GetValue(OpenSettingsCommandProperty); }
            set { SetValue(OpenSettingsCommandProperty, value); }
        }
    }
}
