using System;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Helpers
{
    public delegate void CurrentValueDialogRequestedEventHandler(object sender, CurrentValueDialogRequestedEventArgs eventArgs);

    public class CurrentValueDialogRequestedEventArgs : EventArgs
    {
        public CurrentValueDialogRequestedEventArgs(Axis axis)
        {
            Axis = axis;
        }

        public Axis Axis { get; private set; }
    }
}
