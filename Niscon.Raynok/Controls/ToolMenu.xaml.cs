using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Controls
{
    /// <summary>
    /// Interaction logic for ToolMenu.xaml
    /// </summary>
    public partial class ToolMenu : UserControl
    {
        public ToolMenu()
        {
            InitializeComponent();

            DependencyPropertyDescriptor selectedValueDescriptor = DependencyPropertyDescriptor.FromProperty(SelectedValueProperty, typeof(ToolMenu));
            selectedValueDescriptor.AddValueChanged(this, (sender, args) =>
            {
                SelectedValue?.MenuAction?.Invoke();
            });
            //DataContext = this;
        }

        public static readonly DependencyProperty SelectedValueProperty = DependencyProperty.Register(
            "SelectedValue", typeof(AdminMenuItem), typeof(ToolMenu), new PropertyMetadata(default(AdminMenuItem)));

        public AdminMenuItem SelectedValue
        {
            get { return (AdminMenuItem) GetValue(SelectedValueProperty); }
            set { SetValue(SelectedValueProperty, value); }
        }

        public static readonly DependencyProperty AvailableItemsProperty = DependencyProperty.Register(
            "AvailableItems", typeof(List<AdminMenuItem>), typeof(ToolMenu), new PropertyMetadata(default(List<AdminMenuItem>)));

        public List<AdminMenuItem> AvailableItems
        {
            get { return (List<AdminMenuItem>) GetValue(AvailableItemsProperty); }
            set { SetValue(AvailableItemsProperty, value); }
        }

        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
            "Header", typeof(string), typeof(ToolMenu), new PropertyMetadata(default(string)));

        public string Header
        {
            get { return (string) GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            "Icon", typeof(Image), typeof(ToolMenu), new PropertyMetadata(default(Image)));

        public Image Icon
        {
            get { return (Image) GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
    }
}
