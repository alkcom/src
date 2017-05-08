using System.Collections.ObjectModel;
using System.Linq;
using Niscon.Raynok.Controls;
using Niscon.Raynok.ViewModels;

namespace Niscon.Raynok.Models.Mock
{
    public class WorkspaceContainerMock
    {
        public WorkspaceContainerMock()
        {
            State = WorkspaceState.Ratios;
            Workspace = new WorkspaceViewModel {Nodes = new CueTreeMock().Nodes};
            SelectedNode = Workspace.Nodes.FirstOrDefault();
            SelectedView = new View();

            CurrentShow = new Show
            {
                Cues = new ObservableCollection<Cue>(new CueTreeMock().Nodes),
                Views = new ObservableCollection<View> { new View { IsVisible = true} }
            };
        }

        public WorkspaceState State { get; set; }
        public WorkspaceViewModel Workspace { get; set; }
        public Cue SelectedNode { get; set; }
        public View SelectedView { get; set; }
        public AppSettings AppSettings { get; set; }
        public bool IsCueTreeVisible { get; set; }

        public Show CurrentShow { get; set; }
    }
}
