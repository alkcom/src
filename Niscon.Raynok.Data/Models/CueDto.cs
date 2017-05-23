using System;
using System.Collections.Generic;

namespace Niscon.Raynok.Data.Models
{
    public class CueDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public List<ProfileDto> Profiles { get; set; }

        public List<CueDto> Children { get; set; }
    }
}
