using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using JetBrains.Annotations;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private List<MenuItem> _showsMenuItems;

        private Show _currentShow;

        public WorkspaceViewModel Workspace { get; set; }

        public AppSettings AppSettings { get; set; }

        public List<AdminMenuItem> FileMenuItems { get; set; }

        public List<MenuItem> ShowsMenuItems
        {
            get { return _showsMenuItems; }
            set
            {
                if (Equals(value, _showsMenuItems)) return;
                _showsMenuItems = value;
                OnPropertyChanged();
            }
        }

        public Show CurrentShow
        {
            get { return _currentShow; }
            set
            {
                if (Equals(value, _currentShow)) return;
                _currentShow = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CurrentShow.Name));
                OnPropertyChanged(nameof(CurrentShow.Views));
            }
        }

        public List<Axis> Axes { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
