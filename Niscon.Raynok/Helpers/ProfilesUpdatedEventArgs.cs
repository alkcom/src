using System;
using System.Collections.Generic;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Helpers
{
    public delegate void ProfilesUpdatedEventHandler(object sender, ProfilesUpdatedEventArgs eventArgs);

    public class ProfilesUpdatedEventArgs : EventArgs
    {
        public ProfilesUpdatedEventArgs(IEnumerable<Profile> profiles) : base()
        {
            Profiles = profiles;
        }

        public IEnumerable<Profile> Profiles { get; }
    }
}
