using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using Niscon.Raynok.Converters;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Controls
{
    /// <summary>
    /// Interaction logic for WorkspaceSelector.xaml
    /// </summary>
    public partial class WorkspaceSelector : UserControl
    {
        private bool _firstChange = true;

        public WorkspaceSelector()
        {
            InitializeComponent();

            States = new List<NamedItem>
            {
                new NamedItem("Cue Info View", Controls.WorkspaceState.Grid),
                new NamedItem("Preset View", Controls.WorkspaceState.Presets),
                new NamedItem("Section View", Controls.WorkspaceState.Ratios),
                new NamedItem("3D View", Controls.WorkspaceState._3D),
            };

            StatesListBox.SelectionChanged += StatesListBox_SelectionChanged;

            StatesListBox.SetBinding(Selector.SelectedValueProperty, new Binding
            {
                Path = new PropertyPath("WorkspaceState"),
                Converter = new NamedItemConverter(),
                ConverterParameter = States,
                Mode = BindingMode.TwoWay,
                //TargetNullValue = Controls.WorkspaceState.None
            });

            //StatesListBox.SelectedValue = null;
            WorkspaceState = null;
        }

        private void StatesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //By changing visibility here we are also changing toggle state of top right button, because there are two-way binding in place
            Visibility = Visibility.Collapsed;
        }

        public List<NamedItem> States { get; set; }

        public static readonly DependencyProperty WorkspaceStateProperty = DependencyProperty.Register(
            "WorkspaceState", typeof(WorkspaceState?), typeof(WorkspaceSelector), new PropertyMetadata(default(WorkspaceState?)));

        public WorkspaceState? WorkspaceState
        {
            get { return (WorkspaceState) GetValue(WorkspaceStateProperty); }
            set { SetValue(WorkspaceStateProperty, value); }
        }
    }
}
