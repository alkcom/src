using System.Collections.ObjectModel;
using Niscon.Raynok.ViewModels;

namespace Niscon.Raynok.Models
{
    public class Show : ShowFile
    {
        private ObservableCollection<View> _views;
        private ObservableCollection<Cue> _cues;
        private View _selectedView;

        public ObservableCollection<Cue> Cues
        {
            get { return _cues; }
            set
            {
                if (Equals(value, _cues)) return;
                _cues = value;
                OnPropertyChanged();
            }
        }

        public View SelectedView
        {
            get { return _selectedView; }
            set
            {
                if (Equals(value, _selectedView)) return;
                _selectedView = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<View> Views
        {
            get { return _views; }
            set
            {
                if (Equals(value, _views)) return;
                _views = value;
                OnPropertyChanged();
            }
        }
    }
}
