using System.Windows;
using System.Windows.Controls;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Controls
{
    /// <summary>
    /// Interaction logic for Footer.xaml
    /// </summary>
    public partial class Footer : UserControl
    {
        public Footer()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty SelectedNodeProperty = DependencyProperty.Register(
            "SelectedNode", typeof(Cue), typeof(Footer), new PropertyMetadata(default(Cue)));

        public Cue SelectedNode
        {
            get { return (Cue) GetValue(SelectedNodeProperty); }
            set { SetValue(SelectedNodeProperty, value); }
        }

        public static readonly DependencyProperty IsCueTreeVisibleProperty = DependencyProperty.Register(
            "IsCueTreeVisible", typeof(bool), typeof(Footer), new PropertyMetadata(default(bool)));

        public bool IsCueTreeVisible
        {
            get { return (bool) GetValue(IsCueTreeVisibleProperty); }
            set { SetValue(IsCueTreeVisibleProperty, value); }
        }
    }
}
