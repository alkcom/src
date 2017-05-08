using System;

namespace Niscon.Raynok.Helpers
{
    public delegate void ValueConfirmedEventHandler(object sender, ValueConfirmedEventArgs eventArgs);

    public class ValueConfirmedEventArgs : EventArgs
    {
        public ValueConfirmedEventArgs(string newValue)
        {
            NewValue = newValue;
        }

        public string NewValue { get; private set; }
    }
}
