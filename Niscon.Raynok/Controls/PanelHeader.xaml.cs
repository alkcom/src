using System.Windows;
using System.Windows.Controls;

namespace Niscon.Raynok.Controls
{
    /// <summary>
    /// Interaction logic for PanelHeader.xaml
    /// </summary>
    public partial class PanelHeader : UserControl
    {
        public PanelHeader()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            "Icon", typeof(Image), typeof(PanelHeader), new PropertyMetadata(default(Image)));

        public Image Icon
        {
            get { return (Image) GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text", typeof(string), typeof(PanelHeader), new PropertyMetadata(default(string)));

        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }
}
