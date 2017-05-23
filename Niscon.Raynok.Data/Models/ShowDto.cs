using System.Collections.Generic;

namespace Niscon.Raynok.Data.Models
{
    public class ShowDto : ShowFileDto
    {
        //public List<AxisDto> Axes { get; set; }
        public List<CueDto> Cues { get; set; }
        public List<ViewDto> Views { get; set; }
    }
}
