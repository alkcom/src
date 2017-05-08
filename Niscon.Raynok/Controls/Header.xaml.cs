using System.Windows;
using System.Windows.Controls;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Controls
{
    /// <summary>
    /// Interaction logic for Header.xaml
    /// </summary>
    public partial class Header : UserControl
    {
        public Header()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty RaynokStateProperty = DependencyProperty.Register(
            "RaynokState", typeof(RaynokStates), typeof(Header), new PropertyMetadata(default(RaynokStates)));

        public RaynokStates RaynokState
        {
            get { return (RaynokStates) GetValue(RaynokStateProperty); }
            set { SetValue(RaynokStateProperty, value); }
        }

        public static readonly DependencyProperty IsManualModeProperty = DependencyProperty.Register(
            "IsManualMode", typeof(bool), typeof(Header), new PropertyMetadata(default(bool)));

        public bool IsManualMode
        {
            get { return (bool) GetValue(IsManualModeProperty); }
            set { SetValue(IsManualModeProperty, value); }
        }

        public static readonly DependencyProperty CurrentShowProperty = DependencyProperty.Register(
            "CurrentShow", typeof(Show), typeof(Header), new PropertyMetadata(default(Show)));

        public Show CurrentShow
        {
            get { return (Show) GetValue(CurrentShowProperty); }
            set { SetValue(CurrentShowProperty, value); }
        }
    }
}
