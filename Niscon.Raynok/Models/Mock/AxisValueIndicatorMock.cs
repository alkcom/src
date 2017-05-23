using System;

namespace Niscon.Raynok.Models.Mock
{
    public class AxisValueIndicatorMock
    {
        public AxisValueIndicatorMock()
        {
            Profile = new Profile(new Axis("Grand Border", 200, 10, 350, 1200, 36, TimeSpan.FromSeconds(20), 18, 18, TimeSpan.FromSeconds(10), 600, 1), 50, 300, 36, TimeSpan.FromSeconds(120), 18, 18, TimeSpan.FromSeconds(30), 600, AxisState.Active);
        }

        public Profile Profile { get; set; }
    }
}
