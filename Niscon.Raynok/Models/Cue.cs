using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Niscon.Raynok.Models
{
    public enum CueType
    {
        Default,
        Scene,
        ManualMove,
        RecycleBin
    }

    /// <summary>
    /// Cue tree node in a cue tree
    /// </summary>
    public class Cue : INotifyPropertyChanged
    {
        private string _name;
        private ObservableCollection<Cue> _children;
        public Cue() { }

        //if axis paraemeter list was not passed, for all the axes, we must create dummy list with default parameters
        //their state will always be inactive until an active set of parameters added
        public Cue(string name, IEnumerable<Profile> profiles = null, IEnumerable<Cue> children = null, CueParent cueParent = null)
        {
            Id = Guid.NewGuid();
            Name = name;

            if (profiles != null)
            {
                Profiles = new ObservableCollection<Profile>(profiles);
            }

            if (children != null)
            {
                Children = new ObservableCollection<Cue>();
                AddChildren(children);
            }

            if (cueParent == null)
            {
                CueParent = new CueParent("Cue 27");
            }
        }

        public CueParent CueParent { get; set; }

        public Guid Id { get; set; }

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

        public Cue Parent { get; set; }

        public CueType Type { get; set; }

        public ObservableCollection<Profile> Profiles { get; set; }

        public ObservableCollection<Cue> Children
        {
            get { return _children; }
            set
            {
                if (Equals(value, _children)) return;
                _children = value;
                OnPropertyChanged();
            }
        }

        public void AddChild(Cue node)
        {
            node.Parent = this;
            Children.Add(node);
        }

        public void AddChildren(IEnumerable<Cue> nodes)
        {
            foreach (Cue node in nodes)
            {
                AddChild(node);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Cue Clone()
        {
            return new Cue(Name, Profiles, Children, CueParent)
            {
                Parent = Parent,
                Id = Id
            };
        }
    }
}
