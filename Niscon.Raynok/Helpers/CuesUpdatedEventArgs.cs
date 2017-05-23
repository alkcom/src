using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Helpers
{
    public delegate void CuesUpdatedEventHandler(object sender, CuesUpdatedEventArgs eventArgs);

    public class CuesUpdatedEventArgs : EventArgs
    {
        public CuesUpdatedEventArgs(IEnumerable<Cue> cues) : base()
        {
            Cues = cues;
        }

        public IEnumerable<Cue> Cues { get; }
    }
}
