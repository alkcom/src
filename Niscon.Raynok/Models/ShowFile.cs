using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Niscon.Raynok.Models
{
    /// <summary>
    /// ShowFile
    /// By convention filename will consist of ID, Name and revision looking something like {Id}-{Name}-1.show
    /// Example: {6127a138705841328086b8e6eb6435bb}-Show1-1.show (Id: {6127a138-7058-4132-8086-b8e6eb6435bb}, Name: Show1, Rev: 1)
    /// </summary>
    public class ShowFile : INotifyPropertyChanged
    {
        private int _revision;
        private string _name;

        public Guid Id { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }

        public string FullName => $"{Name}_{Revision}";

        public int Revision
        {
            get { return _revision; }
            set
            {
                if (value == _revision) return;
                _revision = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
