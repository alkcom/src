using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Controls
{
    /// <summary>
    /// Interaction logic for AdminMenuContainer.xaml
    /// </summary>
    public partial class AdminMenuContainer : UserControl
    {
        public AdminMenuContainer()
        {
            InitializeComponent();

            AvailableItems = new List<AdminMenuItem>
            {
                new AdminMenuItem("File"),
                new AdminMenuItem("Setup"),
                new AdminMenuItem("Controllers"),
                new AdminMenuItem("Axis Groups"),
                new AdminMenuItem("Cues"),
                new AdminMenuItem("Commands"),
                new AdminMenuItem("View"),
                new AdminMenuItem("Window"),
                new AdminMenuItem("Help"),
                //new AdminMenuItem("Raynok Online"),
                //new AdminMenuItem("Raynok Edit Mode"),
                //new AdminMenuItem("Raynok Off Line"),
                new AdminMenuItem("Exit", () => Application.Current.Shutdown())
            };
        }

        public static readonly DependencyProperty SelectedValueProperty = DependencyProperty.Register(
            "SelectedValue", typeof(AdminMenuItem), typeof(AdminMenuContainer), new PropertyMetadata(default(AdminMenuItem)));

        public AdminMenuItem SelectedValue
        {
            get { return (AdminMenuItem) GetValue(SelectedValueProperty); }
            set { SetValue(SelectedValueProperty, value); }
        }

        public static readonly DependencyProperty AvailableItemsProperty = DependencyProperty.Register(
            "AvailableItems", typeof(List<AdminMenuItem>), typeof(AdminMenuContainer), new PropertyMetadata(default(List<AdminMenuItem>)));

        public List<AdminMenuItem> AvailableItems
        {
            get { return (List<AdminMenuItem>) GetValue(AvailableItemsProperty); }
            set { SetValue(AvailableItemsProperty, value); }
        }

        public static readonly DependencyProperty AppSettingsProperty = DependencyProperty.Register(
            "AppSettings", typeof(AppSettings), typeof(AdminMenuContainer), new PropertyMetadata(default(AppSettings)));

        public AppSettings AppSettings
        {
            get { return (AppSettings) GetValue(AppSettingsProperty); }
            set { SetValue(AppSettingsProperty, value); }
        }
    }
}
