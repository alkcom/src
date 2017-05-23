using System;

namespace Niscon.Raynok.Data.Models
{
    public class ProfileDto
    {
        public int AxisId { get; set; }

        public double TargetValue { get; set; }

        public double StartingVelocity { get; set; }
        public double Velocity { get; set; }

        public TimeSpan Duration { get; set; }
        public double Acceleration { get; set; }
        public double Deceleration { get; set; }
        public TimeSpan Delay { get; set; }
        public double Load { get; set; }
    }
}
