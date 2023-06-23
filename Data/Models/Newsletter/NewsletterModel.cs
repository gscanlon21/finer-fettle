﻿using Core.Models.Newsletter;
using Data.Models.User;

namespace Data.Models.Newsletter;

/// <summary>
/// Viewmodel for Newsletter.cshtml
/// </summary>
public class NewsletterModel
{
    /// <summary>
    /// The number of footnotes to show in the newsletter
    /// </summary>
    public readonly int FootnoteCount = 2;

    public NewsletterModel(UserNewsletterModel user, Entities.Newsletter.Newsletter newsletter)
    {
        User = user;
        Newsletter = newsletter;
        Verbosity = user.EmailVerbosity;
    }

    public DateOnly Today { get; init; } = DateOnly.FromDateTime(DateTime.UtcNow);

    public UserNewsletterModel User { get; }
    public Entities.Newsletter.Newsletter Newsletter { get; }

    /// <summary>
    /// How much detail to show in the newsletter.
    /// </summary>
    public Verbosity Verbosity { get; }

    public required IList<ExerciseModel> MainExercises { get; init; } = null!;
    public required IList<ExerciseModel> PrehabExercises { get; init; } = null!;
    public required IList<ExerciseModel> RehabExercises { get; init; } = null!;
    public required IList<ExerciseModel> WarmupExercises { get; init; } = null!;
    public required IList<ExerciseModel> SportsExercises { get; init; } = null!;
    public required IList<ExerciseModel> CooldownExercises { get; init; } = null!;
}