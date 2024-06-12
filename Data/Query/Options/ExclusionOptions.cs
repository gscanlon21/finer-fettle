﻿using Core.Models.Exercise.Skills;
using Data.Entities.Exercise;

namespace Data.Query.Options;

public class ExclusionOptions : IOptions
{
    /// <summary>
    /// Will not choose any exercises that fall in this list.
    /// </summary>
    public List<int> ExerciseIds = [];

    /// <summary>
    /// Will not choose any variations that fall in this list.
    /// </summary>
    public List<int> VariationIds = [];

    /// <summary>
    /// Will not choose any variations that fall in this list.
    /// </summary>
    public int ExerciseGroups = 0;

    /// <summary>
    /// Exclude any variation of these exercises from being chosen.
    /// </summary>
    public void AddExcludeExercises(IEnumerable<Exercise>? exercises)
    {
        if (exercises != null)
        {
            ExerciseIds.AddRange(exercises.Select(e => e.Id));
        }
    }

    /// <summary>
    /// Exclude any of these variations from being chosen.
    /// </summary>
    public void AddExcludeVariations(IEnumerable<Variation>? variations)
    {
        if (variations != null)
        {
            VariationIds.AddRange(variations.Select(e => e.Id));
        }
    }

    /// <summary>
    /// Exclude any variations from being chosen that are a part of these exercise groups.
    /// </summary>
    public void AddExcludeGroups(IEnumerable<Exercise>? exercises)
    {
        if (exercises != null)
        {
            ExerciseGroups = exercises.Aggregate(ExerciseGroups, (c, n) => c | n.Skills);
        }
    }

    /// <summary>
    /// Exclude any variations from being chosen that are a part of these exercise groups.
    /// </summary>
    public void AddExcludeGroups(int exerciseGroups)
    {
        ExerciseGroups |= exerciseGroups;
    }
}
