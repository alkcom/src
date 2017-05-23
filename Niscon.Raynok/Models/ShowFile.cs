using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Niscon.Raynok.Models
{
    /// <summary>
    /// ShowFile
    /// </summary>
    public class ShowFile : INotifyPropertyChanged
    {
        private string _name;
        private int? _revision;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public int Revision
        {
            get
            {
                if (!_revision.HasValue)
                {
                    string[] parts = Name.Split('_');
                    _revision = parts.Length > 1 ? int.Parse(parts[1]) : 1;
                }

                return _revision.Value;
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
