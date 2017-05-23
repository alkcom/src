using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Niscon.Raynok.Models
{
    public enum AxisDirection
    {
        None,
        Up,
        Down
    }

    public enum AxisState
    {
        Inactive,
        Active,
        //Selected,
        Error,
        Disabled
    }

    /// <summary>
    /// TODO: add default parameters
    /// </summary>
    public class Axis : INotifyPropertyChanged
    {
        private static readonly IEqualityComparer<Profile> ProfileEqualityComparer = new ProfileIdEqualityComparer();

        private double _currentValue;
        private bool _selected;
        private double _maxVelocity;
        private double _maxAcceleration;
        private double _maxDeceleration;

        public static readonly HashSet<AxisState> AxisStates = new HashSet<AxisState> { AxisState.Error, AxisState.Disabled/*, AxisState.Selected*/};

        public Axis()
        {
            
        }

        public Axis(string name, double currentValue, double minValue, double maxValue, double maxLoad, double velocity,
            TimeSpan duration, double acceleration, double deceleration, TimeSpan delay, double load, int id, AxisState? state = null, bool selected = false, double? maxVelocity = null, double? maxAcceleration = null, double? maxDeceleration = null)
        {
            Name = name;
            CurrentValue = currentValue;
            MinValue = minValue;
            MaxValue = maxValue;
            MaxLoad = maxLoad;
            State = state;
            Selected = selected;

            StartingVelocity = velocity;
            Velocity = velocity;
            Duration = duration;
            Acceleration = acceleration;
            Deceleration = deceleration;
            Delay = delay;
            Load = load;

            Id = id;

            if (maxVelocity.HasValue)
            {
                MaxVelocity = maxVelocity.Value;
            }

            if (maxAcceleration.HasValue)
            {
                MaxAcceleration = maxAcceleration.Value;
            }

            if (maxDeceleration.HasValue)
            {
                MaxDeceleration = maxDeceleration.Value;
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public double CurrentValue
        {
            get { return _currentValue; }
            set
            {
                if (value.Equals(_currentValue)) return;
                _currentValue = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Profile.Direction));
            }
        }

        public double StartValue { get; set; }
        public double MaxValue { get; set; }
        public double MinValue { get; set; }

        public double MaxLoad { get; set; }

        //global axis state. Replaces Profile.State if not null
        public AxisState? State { get; set; }

        public bool Selected
        {
            get { return _selected; }
            set
            {
                if (value == _selected) return;
                _selected = value;
                OnPropertyChanged();
            }
        }

        public double MaxVelocity
        {
            get { return _maxVelocity; }
            set
            {
                if (value.Equals(_maxVelocity)) return;
                _maxVelocity = value;
                OnPropertyChanged();
            }
        }

        public double MaxAcceleration
        {
            get { return _maxAcceleration; }
            set
            {
                if (value.Equals(_maxAcceleration)) return;
                _maxAcceleration = value;
                OnPropertyChanged();
            }
        }

        public double MaxDeceleration
        {
            get { return _maxDeceleration; }
            set
            {
                if (value.Equals(_maxDeceleration)) return;
                _maxDeceleration = value;
                OnPropertyChanged();
            }
        }

        #region Default values

        public double StartingVelocity { get; set; }
        public double Velocity { get; set; }
        public TimeSpan Duration { get; set; }
        public double Acceleration { get; set; }
        public double Deceleration { get; set; }
        public TimeSpan Delay { get; set; }
        public double Load { get; set; }

        #endregion

        public int OrderNumber { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
