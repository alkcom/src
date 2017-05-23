using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niscon.Raynok.Models.Mock
{
    public class MakeCueAutofollowWindowMock
    {
        public MakeCueAutofollowWindowMock()
        {
            Nodes = new ObservableCollection<Cue>
            {
                new Cue("")
            };
        }

        public ObservableCollection<Cue> Nodes { get; }
        public Cue SelectedNode { get; }
    }
}
