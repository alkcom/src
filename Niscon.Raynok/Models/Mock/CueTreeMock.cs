﻿using System.Collections.Generic;

namespace Niscon.Raynok.Models.Mock
{
    public class CueTreeMock
    {
        public CueTreeMock()
        {
            Nodes = new List<Cue>();
            Nodes.AddRange(new []
            {
                new Cue("Main Drape Out"),
                new Cue("Drop In", children: new List<Cue>
                {
                    new Cue("Practical In")
                }),
                new Cue("Scene Change 4", children: new List<Cue>
                {
                    new Cue("Show Reveal")
                }),
                new Cue("Intermission"),
                new Cue("Act II", children: new List<Cue>
                {
                    new Cue("AutoFollow 1"),
                    new Cue("AutoFollow 1")
                }),
                new Cue("End Show")
            });
        }

        public List<Cue> Nodes { get; private set; }
        public Cue SelectedNode { get; set; }
    }
}
