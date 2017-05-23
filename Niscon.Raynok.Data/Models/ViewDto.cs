using System;
using System.Collections.Generic;

namespace Niscon.Raynok.Data.Models
{
    public class ViewDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public bool IsVisible { get; set; }

        /// <summary>
        /// In case of a ViewDto, AxisDto will only contain AxisId
        /// </summary>
        //public List<AxisDto> Axes { get; set; }
        public List<int> AxesIds { get; set; }
    }
}
