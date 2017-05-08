using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Helpers
{
    public class RaynokStateControl : ContentControl
    {
        public RaynokStateControl()
        {
            MouseUp += RaynokStateControl_MouseUp;
        }

        private void RaynokStateControl_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            RaynokStates[] values = Enum.GetValues(typeof(RaynokStates)).Cast<RaynokStates>().ToArray();
            RaynokStates last = values.Max();
            RaynokStates first = values.Min();

            if (State < last)
            {
                State++;
            }
            else
            {
                State = first;
            }
        }

        public static readonly DependencyProperty StateProperty = DependencyProperty.Register(
            "State", typeof(RaynokStates), typeof(RaynokStateControl), new PropertyMetadata(default(RaynokStates)));

        public RaynokStates State
        {
            get { return (RaynokStates) GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }
    }
}
