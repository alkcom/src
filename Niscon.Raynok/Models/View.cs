using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Niscon.Raynok.Models
{
    public enum ViewType
    {
        [Description("Cue Info View")]
        CueInfo,
        [Description("Preset View")]
        Preset,
        [Description("Section View")]
        Section,
        [Description("3D View")]
        _3D
    }

    public class View : INotifyPropertyChanged
    {
        private bool _isVisible;
        private bool _isSelected;

        public Guid Id { get; set; }
        public string Name { get; set; }
        public ViewType Type { get; set; }

        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                if (value == _isVisible) return;
                _isVisible = value;
                OnPropertyChanged();
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value == _isSelected) return;
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Axis> Axes { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public View Clone()
        {
            return new View
            {
                Id = Id,
                Name = Name,
                Type = Type,
                IsVisible = IsVisible,
                IsSelected = IsSelected,
                Axes = new ObservableCollection<Axis>(Axes)
            };
        }
    }
}
