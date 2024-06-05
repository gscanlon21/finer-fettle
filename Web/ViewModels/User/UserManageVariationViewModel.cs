﻿using Core.Consts;
using Core.Models.Newsletter;
using Data.Entities.Exercise;
using Data.Entities.User;
using Lib.ViewModels.Newsletter;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.User;

/// <summary>
/// For CRUD actions
/// </summary>
public class UserManageVariationViewModel
{
    private static DateOnly Today => DateOnly.FromDateTime(DateTime.UtcNow);

    [Obsolete("Public parameterless constructor for model binding.", error: true)]
    public UserManageVariationViewModel() { }

    public UserManageVariationViewModel(IList<UserVariationWeight>? userWeights, UserVariation? current)
    {
        if (userWeights != null && current != null)
        {
            // Skip today, start at 1, because we append the current weight onto the end regardless.
            Xys = Enumerable.Range(1, 365).Select(i =>
            {
                var date = Today.AddDays(-i);
                return new Xy(date, userWeights.FirstOrDefault(uw => uw.Date == date)?.Weight);
            }).Where(xy => xy.Y.HasValue).Reverse().Append(new Xy(Today, current.Weight)).ToList();
        }

        if (userWeights != null && current != null)
        {
            // Skip today, start at 1, because we append the current weight onto the end regardless.
            SetXys = Enumerable.Range(1, 365).Select(i =>
            {
                var date = Today.AddDays(-i);
                return new Xy(date, userWeights.FirstOrDefault(uw => uw.Date == date)?.Sets);
            }).Where(xy => xy.Y.HasValue).Reverse().Append(new Xy(Today, current.Sets)).ToList();
        }

        if (userWeights != null && current != null)
        {
            // Skip today, start at 1, because we append the current weight onto the end regardless.
            RepXys = Enumerable.Range(1, 365).Select(i =>
            {
                var date = Today.AddDays(-i);
                return new Xy(date, userWeights.FirstOrDefault(uw => uw.Date == date)?.Reps);
            }).Where(xy => xy.Y.HasValue).Reverse().Append(new Xy(Today, current.Reps)).ToList();
        }
    }

    public required UserManageExerciseVariationViewModel.Parameters Parameters { get; init; }

    public required Data.Entities.User.User User { get; init; }

    [Display(Name = "Refreshes After", Description = "Refresh this variation—the next workout will try and select a new exercise variation if available.")]
    public required UserVariation UserVariation { get; init; }

    [Display(Name = "Variation", Description = "Ignore this variation for just this section.")]
    public required Variation Variation { get; init; }

    public required IList<ExerciseVariationViewModel> Variations { get; init; } = null!;

    public Verbosity VariationVerbosity => Verbosity.Instructions | Verbosity.Images;

    [Display(Name = "Section")]
    public required Section VariationSection { get; init; }

    [Required, Range(0, 999)]
    [Display(Name = "How much weight are you able to lift?")]
    public int Weight { get; init; }

    [Required, Range(0, 6)]
    [Display(Name = "How many sets did you perform?")]
    public int Sets { get; init; }

    [Required, Range(0, 30)]
    [Display(Name = "How many reps did you perform?")]
    public int Reps { get; init; }

    [Required, Range(UserConsts.RefreshEveryXWeeksMin, UserConsts.RefreshEveryXWeeksMax)]
    [Display(Name = "Refresh Every X Weeks", Description = "How often do you want to refresh this variation?")]
    public int RefreshEveryXWeeks { get; init; }

    internal IList<Xy> Xys { get; init; } = [];

    internal IList<Xy> RepXys { get; init; } = [];

    internal IList<Xy> SetXys { get; init; } = [];

    /// <summary>
    /// For chart.js
    /// </summary>
    internal record Xy(string X, int? Y)
    {
        internal Xy(DateOnly x, int? y) : this(x.ToString("O"), y) { }
    }
}
