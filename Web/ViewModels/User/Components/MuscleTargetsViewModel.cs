﻿using Core.Models.Exercise;
using Data.Entities.User;

namespace Web.ViewModels.User.Components;

/// <summary>
/// Viewmodel for MonthlyMuscles.cshtml
/// </summary>
public class MuscleTargetsViewModel
{
    public required string Token { get; set; }
    public required Data.Entities.User.User User { get; set; }

    public int Weeks { get; set; }

    public required IDictionary<MuscleGroups, int?> WeeklyVolume { get; set; }

    public MuscleGroups UsersWorkedMuscles { get; init; }

    /// <summary>
    /// The avg minimum number of seconds per week each muscle group should be under tension.
    /// </summary>
    public double MinSecsPerWeek = Math.Round(UserMuscleStrength.MuscleTargets.Values.Average(r => r.Start.Value));

    /// <summary>
    /// The avg maximum number of seconds per week each muscle group should be under tension.
    /// </summary>
    public double MaxSecsPerWeek = Math.Round(UserMuscleStrength.MuscleTargets.Values.Average(r => r.End.Value));

    // The max value (seconds of time-under-tension) of the range display
    public double MaxRangeValue = UserMuscleStrength.MuscleTargets.Values.Max(r => r.End.Value);

    public MonthlyMuscle GetMuscleTarget(MuscleGroups muscleGroup)
    {
        var userMuscleTarget = User.UserMuscleStrengths.Cast<UserMuscleStrength?>().FirstOrDefault(um => um?.MuscleGroup == muscleGroup)?.Range ?? UserMuscleStrength.MuscleTargets[muscleGroup];
        var defaultMuscleTarget = UserMuscleStrength.MuscleTargets[muscleGroup];

        return new MonthlyMuscle()
        {
            MuscleGroup = muscleGroup,
            UserMuscleTarget = userMuscleTarget,
            Start = userMuscleTarget.Start.Value / MaxRangeValue * 100,
            End = userMuscleTarget.End.Value / MaxRangeValue * 100,
            DefaultStart = defaultMuscleTarget.Start.Value / MaxRangeValue * 100,
            DefaultEnd = defaultMuscleTarget.End.Value / MaxRangeValue * 100,
            ValueInRange = Math.Min(101, (WeeklyVolume[muscleGroup] ?? 0) / MaxRangeValue * 100),
            IsMinVolumeInRange = WeeklyVolume[muscleGroup] >= userMuscleTarget.Start.Value,
            IsMaxVolumeInRange = WeeklyVolume[muscleGroup] <= userMuscleTarget.End.Value,
            ShowButtons = UsersWorkedMuscles.HasFlag(muscleGroup),
        };
    }

    public class MonthlyMuscle
    {
        public required MuscleGroups MuscleGroup { get; init; }
        public required bool ShowButtons { get; init; }
        public required Range UserMuscleTarget { get; init; }
        public required double Start { get; init; }
        public required double End { get; init; }
        public required double DefaultStart { get; init; }
        public required double DefaultEnd { get; init; }
        public required double ValueInRange { get; init; }
        public required bool IsMinVolumeInRange { get; init; }
        public required bool IsMaxVolumeInRange { get; init; }
    }
}