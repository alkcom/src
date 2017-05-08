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

            Axis.AddProfile(this);

            StartValue = startValue ?? Axis.GetPreviousProfile(this)?.TargetValue ?? Axis.MinValue;
            TargetValue = targetValue ?? StartValue;
            StartingVelocity = velocity ?? axis.Velocity;
            Velocity = velocity ?? axis.Velocity;
            Duration = duration ?? axis.Duration;
            Acceleration = acceleration ?? axis.Acceleration;
            Deceleration = deceleration ?? axis.Deceleration;
            Delay = delay ?? axis.Delay;
            Load = load ?? axis.Load;

            State = state;
        }

        public Guid Id { get; set; }

        public Guid AxisId { get; set; }

        [JsonIgnore]
        public Axis Axis { get; set; }

        public AxisDirection Direction => 
            TargetValue > StartValue
                ? AxisDirection.Up
                : TargetValue < StartValue ? AxisDirection.Down : AxisDirection.None;

        public double StartValue { get; set; }

        public double TargetValue { get; set; }

        public double StartingVelocity { get; set; }
        public double Velocity { get; set; }

        /// <summary>
        /// Maximum velocity
        /// Assuming that this value is a maximum possible velocity
        /// In case of acceleration being greater than deceleration maximum velocity will be equal to velocity at the end of given duration
        /// In case of deceleration being greater than acceleration maximum velocity will be equal to velocity at the start of given duration
        /// </summary>
        public double MaxVelocity
        {
            get
            {
                return Acceleration > Deceleration
                    ? Velocity + (Acceleration - Deceleration) * Duration.TotalMinutes
                    : StartingVelocity;
            }
        }

        public TimeSpan Duration { get; set; }
        public double Acceleration { get; set; }
        public double Deceleration { get; set; }
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

        public bool IsFiller { get; set; }

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
            //if (Axis.State.HasValue && Axis.State != AxisState.Selected)
            //{
            //    return;
            //}

            //if (!Axis.State.HasValue)
            //{
            //    SetAxisState(AxisState.Selected);
            //}
            //else if (Axis.State.Value == AxisState.Selected)
            //{
            //    SetAxisState(null);
            //}

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