using System;

namespace Niscon.Raynok.Helpers
{
    public delegate void OnScreenKeyboardButtonValidateEventHandler(object sender,
        OnScreenKeyboardButtonValidateEventArgs eventArgs);

    public class OnScreenKeyboardButtonValidateEventArgs : EventArgs
    {
        public OnScreenKeyboardButtonValidateEventArgs(string oldText, string newText)
        {
            OldText = oldText;
            NewText = newText;
            IsValid = true;
        }

        public bool IsValid { get; set; }
        public string OldText { get; }
        public string NewText { get; }
    }
}
