using System;

namespace Nyscon.Raynok.Data.Models
{
    public class AxisBaseDto
    {
        public Guid Id { get; set; }
    }

    public class AxisDto : AxisBaseDto
    {
        public string Name { get; set; }

        public double MaxValue { get; set; }
        public double MinValue { get; set; }

        public double MaxLoad { get; set; }

        #region Default values

        public double StartingVelocity { get; set; }
        public double Velocity { get; set; }
        public TimeSpan Duration { get; set; }
        public double Acceleration { get; set; }
        public double Deceleration { get; set; }
        public TimeSpan Delay { get; set; }
        public double Load { get; set; }

        #endregion

        public int OrderNumber { get; set; }
    }
}
