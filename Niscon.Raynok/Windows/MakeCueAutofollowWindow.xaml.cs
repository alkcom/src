using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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

        public static readonly DependencyProperty CueNameProperty = DependencyProperty.Register(
            "CueName", typeof(string), typeof(MakeCueAutofollowWindow), new PropertyMetadata(default(string)));

        public string CueName
        {
            get { return (string) GetValue(CueNameProperty); }
            set { SetValue(CueNameProperty, value); }
        }

        private void AfParametersButton_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("AF parameters");
        }

        private void OkButton_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (SelectedNode == null)
            {
                MessageBox.Show("You did not select a cue!");
                return;
            }

            if (string.IsNullOrEmpty(CueName))
            {
                MessageBox.Show("Please, specify cue name");
                return;
            }

            DialogResult = true;
            Close();
        }

        private void CancelButton_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
