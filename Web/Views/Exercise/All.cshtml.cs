﻿using Core.Dtos.Newsletter;
using Core.Models.Equipment;
using Core.Models.Exercise;
using Core.Models.Newsletter;
using Core.Models.User;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Exercise;

public class ExercisesViewModel : IValidatableObject
{
    public ExercisesViewModel() { }

    [ValidateNever]
    public IList<ExerciseVariationDto> Exercises { get; set; } = null!;

    public Verbosity Verbosity => Verbosity.Debug;

    [Display(Name = "Exercise Name")]
    public string? Name { get; init; }

    [Display(Name = "Mobility Joints")]
    public Joints? Joints { get; init; }

    [Display(Name = "Sports Focus")]
    public SportsFocus? SportsFocus { get; init; }

    [Display(Name = "Strength Muscle")]
    public MuscleGroups? StrengthMuscle { get; init; }

    [Display(Name = "Secondary Muscle")]
    public MuscleGroups? SecondaryMuscle { get; init; }

    [Display(Name = "Stretch Muscle")]
    public MuscleGroups? StretchMuscle { get; init; }

    [Display(Name = "Movement Patterns")]
    public MovementPattern? MovementPatterns { get; init; }

    [Display(Name = "Visual Skills")]
    public int? VisualSkills { get; init; }

    [Display(Name = "Cervical Skills")]
    public int? CervicalSkills { get; init; }

    [Display(Name = "Muscle Movement")]
    public MuscleMovement? MuscleMovement { get; init; }

    [Display(Name = "Exercise Focus")]
    public ExerciseFocus? ExerciseFocus { get; init; }

    [Display(Name = "Section")]
    public Section? Section { get; init; }

    [Display(Name = "Equipment")]
    public Equipment? Equipment { get; init; }

    public bool FormOpen { get; set; }

    public bool FormHasData =>
        !string.IsNullOrWhiteSpace(Name)
        || ExerciseFocus.HasValue
        || Section.HasValue
        || Equipment.HasValue
        || StrengthMuscle.HasValue
        || SecondaryMuscle.HasValue
        || StretchMuscle.HasValue
        || MovementPatterns.HasValue
        || MuscleMovement.HasValue
        || Joints.HasValue
        || VisualSkills.HasValue
        || CervicalSkills.HasValue
        || SportsFocus.HasValue;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        List<MuscleGroups?> allMuscles = [StrengthMuscle, StretchMuscle, SecondaryMuscle];
        if (allMuscles.Count(mg => mg.HasValue) > 1)
        {
            yield return new ValidationResult("Only one muscle group may be selected.");
        }

        List<int?> allSkills = [VisualSkills, CervicalSkills];
        if (allSkills.Count(mg => mg.HasValue) > 1)
        {
            yield return new ValidationResult("Only one skill group may be selected.");
        }
    }
}
