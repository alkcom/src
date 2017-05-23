using System;
using System.Collections.Generic;

namespace Niscon.Raynok.Models.Mock
{
    public class ProfilesMock
    {
        public ProfilesMock()
        {


            Profiles = new List<Profile>
            {
                new Profile(new Axis("Grand Border", 222, 50, 350, 1200, 36, TimeSpan.FromSeconds(20), 18, 18, TimeSpan.FromSeconds(10), 600, 1, selected: true, maxVelocity: 60), 100, 100, 30, TimeSpan.FromSeconds(120), 60, 60, TimeSpan.FromSeconds(30), 600),
                new Profile(new Axis("Grand Drape", 222, 50, 350, 1800, 36, TimeSpan.FromSeconds(20), 18, 18, TimeSpan.FromSeconds(10), 600, 2, selected:true), 100, 48, 240, TimeSpan.FromSeconds(42), 222, 222, TimeSpan.FromSeconds(30), 1800, AxisState.Active),
                new Profile(new Axis("Electric #1", 222, 50, 350, 1900, 36, TimeSpan.FromSeconds(20), 18, 18, TimeSpan.FromSeconds(10), 600, 3, state: AxisState.Disabled), 100, 48, 20, TimeSpan.FromSeconds(42), 222, 222, TimeSpan.FromSeconds(30), 1750),
                new Profile(new Axis("Scenery", 222, 50, 350, 600, 36, TimeSpan.FromSeconds(20), 18, 18, TimeSpan.FromSeconds(10), 600, 4, state: AxisState.Error), 100, 48, 120, TimeSpan.FromSeconds(42), 222, 222, TimeSpan.FromSeconds(30), 135),
                new Profile(new Axis("Border", 48, 10, 350, 1200, 36, TimeSpan.FromSeconds(20), 18, 18, TimeSpan.FromSeconds(10), 600, 5), 100, 222, 120, TimeSpan.FromSeconds(42), 222, 222, TimeSpan.FromSeconds(30), 286),
                new Profile(new Axis("Electric #2", 46, 20, 350, 1800, 36, TimeSpan.FromSeconds(20), 18, 18, TimeSpan.FromSeconds(10), 600, 6), 100, 222, 120, TimeSpan.FromSeconds(42), 222, 222, TimeSpan.FromSeconds(30), 1500, AxisState.Active),
                new Profile(new Axis("Scrim", 222, 80, 350, 1200, 36, TimeSpan.FromSeconds(20), 18, 18, TimeSpan.FromSeconds(10), 600, 7), 100, 40, 120, TimeSpan.FromSeconds(42), 222, 222, TimeSpan.FromSeconds(30), 364, AxisState.Active),

            };
        }

        public List<Profile> Profiles { get; private set; }
    }
}
