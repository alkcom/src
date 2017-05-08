using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Controls
{
    public class AxesDisplayControl : UserControl
    {
        public static readonly DependencyProperty ProfilesProperty = DependencyProperty.Register(
            "Profiles", typeof(List<Profile>), typeof(AxesDisplayControl), new PropertyMetadata(default(List<Profile>)));

        public List<Profile> Profiles
        {
            get { return (List<Profile>)GetValue(ProfilesProperty); }
            set { SetValue(ProfilesProperty, value); }
        }
    }
}
