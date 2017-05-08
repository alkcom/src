using System;
using System.ComponentModel;
using System.Timers;

namespace Niscon.Raynok.Helpers
{
    public class TimeTicker : INotifyPropertyChanged
    {
        public DateTime Now { get { return DateTime.Now; } }

        public TimeTicker()
        {
            Timer timer = new Timer {Interval = 1000};// 1 second updates
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (PropertyChanged != null)
                 PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Now"));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
