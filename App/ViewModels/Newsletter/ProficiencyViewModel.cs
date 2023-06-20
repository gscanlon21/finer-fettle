﻿using App.Dtos.Exercise;
using App.Dtos.User;

namespace App.ViewModels.Newsletter;

/// <summary>
/// Viewmodel for Proficiency.cshtml
/// </summary>
public class ProficiencyViewModel
{
    public ProficiencyViewModel(Intensity intensity, User.UserNewsletterViewModel? user, UserVariation? userVariation, bool demo)
    {
        Intensity = intensity;
        UserVariation = userVariation;
        User = user;
        Demo = demo;
    }

    public bool Demo { get; }
    public Intensity Intensity { get; }
    public User.UserNewsletterViewModel? User { get; }
    public UserVariation? UserVariation { get; }

    public bool ShowName { get; init; } = false;
    public bool FirstTimeViewing { get; init; } = false;
}
