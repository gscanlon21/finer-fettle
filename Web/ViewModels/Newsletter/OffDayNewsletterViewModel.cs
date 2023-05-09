﻿using Web.Models.Newsletter;
using Web.ViewModels.User;

namespace Web.ViewModels.Newsletter;

/// <summary>
/// Viewmodel for OffDayNewsletter.cshtml
/// </summary>
public class OffDayNewsletterViewModel
{
    /// <summary>
    /// The number of footnotes to show in the newsletter
    /// </summary>
    public readonly int FootnoteCount = 2;

    public OffDayNewsletterViewModel(UserNewsletterViewModel user, Entities.Newsletter.Newsletter newsletter)
    {
        User = user;
        Newsletter = newsletter;
        Verbosity = user.EmailVerbosity;
    }

    public UserNewsletterViewModel User { get; }
    public IList<ExerciseViewModel> MobilityExercises { get; init; } = null!;
    public IList<ExerciseViewModel> FlexibilityExercises { get; init; } = null!;
    public Entities.Newsletter.Newsletter Newsletter { get; }

    /// <summary>
    /// How much detail to show in the newsletter.
    /// </summary>
    public Verbosity Verbosity { get; private init; }
}