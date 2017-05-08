using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Extensions
{
    public static class ModelExtensions
    {
        public static void FillCues(this IEnumerable<Cue> cues, List<Axis> axes, Cue parent = null)
        {
            foreach (Cue cue in cues)
            {
                if (parent != null)
                {
                    cue.Parent = parent;
                }

                cue.Profiles = cue.Profiles.FillEmptyAxes(axes);
                if (cue.Children != null && cue.Children.Any())
                {
                    FillCues(cue.Children, axes, cue);
                }
            }
        }

        /// <summary>
        /// Fills views by matching axes IDs
        /// </summary>
        /// <param name="views"></param>
        /// <param name="axes"></param>
        public static void FillViews(this IEnumerable<View> views, List<Axis> axes)
        {
            IEnumerable<View> enumerable = views as View[] ?? views.ToArray();
            if (enumerable.Any() && enumerable.All(v => !v.IsSelected))
            {
                enumerable.First().IsSelected = true;
            }

            Dictionary<Guid, Axis> axesDict = axes.ToDictionary(a => a.Id);

            foreach (View view in enumerable)
            {
                for (int i = 0; i < view.Axes.Count; i++)
                {
                    Axis axis = view.Axes[i];

                    if (!axesDict.ContainsKey(axis.Id))
                    {
                        throw new ArgumentOutOfRangeException(nameof(view), $@"View {view.Name} contains invalid axis reference with Id {axis.Id}");
                    }

                    view.Axes[i] = axesDict[axis.Id];
                }
            }
        }

        public static List<Profile> ToDefaultParameters(this IEnumerable<Axis> axes)
        {
            List<Profile> axesParameters = new List<Profile>();

            foreach (Axis axis in axes)
            {
                axesParameters.Add(new Profile(axis));
            }

            return axesParameters;
        }

        public static ObservableCollection<Profile> FillEmptyAxes(this IEnumerable<Profile> profiles,
            IEnumerable<Axis> cueAxes)
        {
            Dictionary<Guid, Profile> profilesDict = profiles.ToDictionary(ap => ap.AxisId);
            ObservableCollection<Profile> newProfilesDict = new ObservableCollection<Profile>();

            foreach (Axis axis in cueAxes)
            {
                Profile newProfile = profilesDict.ContainsKey(axis.Id)
                    ? profilesDict[axis.Id]
                    : new Profile(axis) { IsFiller = true, State = AxisState.Inactive };

                axis.AddProfile(newProfile);

                newProfilesDict.Add(newProfile);
            }

            return newProfilesDict;
        }
    }
}
