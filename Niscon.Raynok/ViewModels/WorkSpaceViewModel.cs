using System.Collections.Generic;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.ViewModels
{
    public class WorkspaceViewModel
    {
        public List<Cue> Nodes { get; set; }
        public List<Axis> Axes { get; set; }
    }
}
