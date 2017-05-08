using System;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Helpers
{
    public delegate void LockOptionsRequestedEventHandler(object sender, LockOptionsRequesetedEventArgs eventArgs);

    public class LockOptionsRequesetedEventArgs : EventArgs
    {
        public LockOptionsRequesetedEventArgs(Profile profile)
        {
            Profile = profile;
        }

        public Profile Profile { get; private set; }
    }
}
