using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Niscon.Raynok.Models
{
    public class ProfileIdEqualityComparer : IEqualityComparer<Profile>
    {
        public bool Equals(Profile x, Profile y)
        {
            return x.Id.Equals(y.Id);
        }

        public int GetHashCode(Profile obj)
        {
            return obj.Id.GetHashCode();
        }
    }

    public class Profile : INotifyPropertyChanged
    {
        //public static readonly HashSet<AxisState> Pr = new HashSet<AxisState> { AxisState.Active, AxisState.Inactive };

        private AxisState _state;
        private double _targetValue;
        private double _startValue;
        private double _velocity;
        private double _acceleration;
        private double _deceleration;
        public Profile() { }

        public Profile(Axis axis, double? startValue = null, double? targetValue = null, double? velocity = null,
            TimeSpan? duration = null, double? acceleration = null, double? deceleration = null, TimeSpan? delay = null, double? load = null,
            AxisState state = AxisState.Inactive)
        {
            if (axis == null)
            {
                throw new ArgumentNullException(nameof(axis));
            }

            Axis = axis;
            AxisId = axis.Id;

            //Axis.AddProfile(this);

            if (startValue.HasValue)
            {
                StartValue = startValue.Value;
            }
            //StartValue = startValue ?? Axis.GetPreviousProfile(this)?.TargetValue ?? Axis.MinValue;
            TargetValue = targetValue ?? StartValue;
            StartingVelocity = velocity ?? axis.Velocity;
            Velocity = velocity ?? 0;
            Duration = duration ?? axis.Duration;
            Acceleration = acceleration ?? axis.Acceleration;
            Deceleration = deceleration ?? axis.Deceleration;
            Delay = delay ?? axis.Delay;
            Load = load ?? axis.Load;

            State = state;
        }

        public Guid Id { get; set; }

        public int AxisId { get; set; }

        [JsonIgnore]
        public Axis Axis { get; set; }

        public AxisDirection Direction => 
            TargetValue > StartValue
                ? AxisDirection.Up
                : TargetValue < StartValue ? AxisDirection.Down : AxisDirection.None;

        public double StartValue
        {
            get { return _startValue; }
            set
            {
                if (value.Equals(_startValue)) return;
                _startValue = value;

                State = IsFiller ? AxisState.Inactive : AxisState.Active;

                OnPropertyChanged();
                OnPropertyChanged(nameof(Direction));
                OnPropertyChanged(nameof(State));
                OnPropertyChanged(nameof(IsFiller));
            }
        }

        public double TargetValue
        {
            get { return _targetValue; }
            set
            {
                if (value.Equals(_targetValue)) return;
                _targetValue = value;

                State = IsFiller ? AxisState.Inactive : AxisState.Active;

                OnPropertyChanged();
                OnPropertyChanged(nameof(Direction));
                OnPropertyChanged(nameof(State));
                OnPropertyChanged(nameof(IsFiller));
            }
        }

        public double StartingVelocity { get; set; }

        public double Velocity
        {
            get { return _velocity; }
            set
            {
                if (value.Equals(_velocity)) return;
                _velocity = value;
                if (_velocity > Axis?.MaxVelocity)
                {
                    _velocity = Axis.MaxVelocity;
                }
                OnPropertyChanged();
            }
        }

        public TimeSpan Duration { get; set; }

        public double Acceleration
        {
            get { return _acceleration; }
            set
            {
                if (value.Equals(_acceleration)) return;
                _acceleration = value;
                if (_acceleration > Axis?.MaxAcceleration)
                {
                    _acceleration = Axis.MaxAcceleration;
                }
                OnPropertyChanged();
            }
        }

        public double Deceleration
        {
            get { return _deceleration; }
            set
            {
                if (value.Equals(_deceleration)) return;
                _deceleration = value;
                if (_deceleration > Axis?.MaxDeceleration)
                {
                    _deceleration = Axis.MaxDeceleration;
                }
                OnPropertyChanged();
            }
        }

        public TimeSpan Delay { get; set; }
        public double Load { get; set; }

        public AxisState State
        {
            get
            {
                return Axis?.State ?? _state;
            }
            //settings the state works in a following way:
            //first we check if state is on of the AxisOnlyStates, if that's true, we assign state to axis
            //otherwise we assign state to Profile
            set
            {
                if (value == _state) return;

                _state = value;

                //only fire Property Changed event, if we do not have parent state
                if (Axis?.State == null)
                {
                    OnPropertyChanged();
                }
            }
        }

        public string Status
        {
            get
            {
                return State == AxisState.Active || State == AxisState.Inactive ? "Ready" : State.ToString();
            }
        }

        public bool IsFiller
        {
            get { return TargetValue == StartValue; }
        }

        public void SetAxisState(AxisState? state)
        {
            if (Axis.State == state)
            {
                return;
            }

            Axis.State = state;
            OnPropertyChanged(nameof(State));
        }

        public void ToggleAxisSelectedState()
        {
            Axis.Selected = !Axis.Selected;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}