using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Windows
{
    /// <summary>
    /// Interaction logic for MakeCueAutofollowWindow.xaml
    /// </summary>
    public partial class MakeCueAutofollowWindow : Window
    {
        public MakeCueAutofollowWindow()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty NodesProperty = DependencyProperty.Register(
            "Nodes", typeof(ObservableCollection<Cue>), typeof(MakeCueAutofollowWindow), new PropertyMetadata(default(ObservableCollection<Cue>)));

        public ObservableCollection<Cue> Nodes
        {
            get { return (ObservableCollection<Cue>) GetValue(NodesProperty); }
            set { SetValue(NodesProperty, value); }
        }

        public static readonly DependencyProperty SelectedNodeProperty = DependencyProperty.Register(
            "SelectedNode", typeof(Cue), typeof(MakeCueAutofollowWindow), new PropertyMetadata(default(Cue)));

        public Cue SelectedNode
        {
            get { return (Cue) GetValue(SelectedNodeProperty); }
            set { SetValue(SelectedNodeProperty, value); }
        }

        public static readonly DependencyProperty AutofollowNodeProperty = DependencyProperty.Register(
            "AutofollowNode", typeof(Cue), typeof(MakeCueAutofollowWindow), new PropertyMetadata(default(Cue)));

        public Cue AutofollowNode
        {
            get { return (Cue) GetValue(AutofollowNodeProperty); }
            set { SetValue(AutofollowNodeProperty, value); }
        }

        private void AfParameters_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = AutofollowNode?.Parent != null && AutofollowNode.Parent.Type == CueType.Default;
        }

        private void AfParameters_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AfParametersWindow window = new AfParametersWindow
            {
                Cue = AutofollowNode,
                Owner = this
            };

            window.ShowDialog();
        }

        private void Ok_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = SelectedNode != null;
        }

        private void Ok_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Cancel_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
