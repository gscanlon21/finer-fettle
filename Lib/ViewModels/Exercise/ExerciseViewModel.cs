﻿using Core.Consts;
using Core.Models.Exercise;
using Lib.ViewModels.User;
using System.ComponentModel.DataAnnotations;

using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Lib.ViewModels.Exercise;

/// <summary>
/// Exercises listed on the website
/// </summary>
[DebuggerDisplay("{Name,nq}")]
public class ExerciseViewModel
{
    public int Id { get; init; }

    /// <summary>
    /// Friendly name.
    /// </summary>
    [Required]
    public string Name { get; init; } = null!;

    /// <summary>
    /// The progression level needed to attain proficiency in the exercise
    /// </summary>
    [Required, Range(UserConsts.MinUserProgression, UserConsts.MaxUserProgression)]
    public int Proficiency { get; init; }

    /// <summary>
    /// Similar groups of exercises.
    /// </summary>
    [Required]
    public ExerciseGroup Groups { get; init; }

    /// <summary>
    /// Notes about the variation (externally shown).
    /// </summary>
    public string? Notes { get; init; } = null;

    public string? DisabledReason { get; init; } = null;

    [JsonInclude]
    public ICollection<ExercisePrerequisite> Prerequisites { get; init; } = null!;

    [JsonInclude]
    public ICollection<ExercisePrerequisite> PrerequisiteExercises { get; init; } = null!;

    [JsonInclude]
    public ICollection<ExerciseVariationViewModel> ExerciseVariations { get; init; } = null!;

    [JsonInclude]
    public ICollection<UserExerciseViewModel> UserExercises { get; init; } = null!;

    public override int GetHashCode() => HashCode.Combine(Id);

    public override bool Equals(object? obj) => obj is ExerciseViewModel other
        && other.Id == Id;
}
