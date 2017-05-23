using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Extensions
{
    public static class ModelExtensions
    {
        public static void FillCues(this IEnumerable<Cue> cues, List<Axis> axes)
        {
            FillCuesInternal(cues);
            FillProfiles(cues, axes);
        }

        public static void FillProfiles(this IEnumerable<Cue> cues, List<Axis> axes)
        {
            if (cues == null)
            {
                return;
            }

            if (cues.Any(c => c.Type == CueType.Scene))
            {
                foreach (Cue scene in cues)
                {
                    ObservableCollection<Profile> newProfiles = new ObservableCollection<Profile>();
                    foreach (Axis axis in axes)
                    {
                        Profile newProfile = new Profile(axis) { State = AxisState.Inactive };
                        newProfile.StartValue = axis.StartValue;
                        newProfile.TargetValue = newProfile.StartValue;
                        

                        newProfile.Axis = axis;
                        newProfiles.Add(newProfile);
                    }

                    scene.Profiles = newProfiles;

                    FillProfiles(scene.Children, axes);
                }

                return;
            }

            IEnumerable<Cue> flattenCues = cues.Expand(c => c.Children);

            Cue previousCue = null;
            foreach (Cue cue in flattenCues)
            {
                Dictionary<int, Profile> profilesDict = cue.Profiles.ToDictionary(ap => ap.AxisId);
                ObservableCollection<Profile> newProfiles = new ObservableCollection<Profile>();

                foreach (Axis axis in axes)
                {
                    Profile newProfile;
                    if (profilesDict.ContainsKey(axis.Id))
                    {
                        newProfile = profilesDict[axis.Id];
                        newProfile.StartValue = previousCue != null
                            ? previousCue.Profiles.First(p => p.AxisId == axis.Id).TargetValue
                            : axis.StartValue;
                    }
                    else
                    {
                        newProfile = new Profile(axis) {State = AxisState.Inactive};
                        newProfile.StartValue = previousCue != null
                            ? previousCue.Profiles.First(p => p.AxisId == axis.Id).TargetValue
                            : axis.StartValue;
                        newProfile.TargetValue = newProfile.StartValue;
                    }

                    newProfile.Axis = axis;
                    newProfiles.Add(newProfile);
                }

                cue.Profiles = newProfiles;

                previousCue = cue;
            }
        }

        private static void FillCuesInternal(this IEnumerable<Cue> cues, Cue parent = null)
        {
            foreach (Cue cue in cues)
            {
                if (parent != null)
                {
                    cue.Parent = parent;
                }

                //cue.Profiles = cue.Profiles.FillEmptyAxes(axes);
                if (cue.Children != null && cue.Children.Any())
                {
                    FillCuesInternal(cue.Children, cue);
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

            Dictionary<int, Axis> axesDict = axes.ToDictionary(a => a.Id);

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

        public static string UpdateRevision(this string showName, int revision)
        {
            Regex revisionRegEx = new Regex(@"^(.+)_(\d+)$");
            if (revisionRegEx.IsMatch(showName))
            {
                return revisionRegEx.Replace(showName, $"$1_{revision}");
            }
            else
            {
                return $"{showName}_{revision}";
            }
        }
    }
}
