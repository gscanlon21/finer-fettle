﻿using Web.Entities.Exercise;

namespace Web.Data.Query.Options;

public class ExclusionOptions
{
    private readonly List<Exercise> _exercises = new();
    private readonly List<Variation> _variations = new();

    /// <summary>
    /// Will not choose any exercises that fall in this list.
    /// </summary>
    public IEnumerable<int> ExerciseIds => _exercises.Select(e => e.Id);

    /// <summary>
    /// Will not choose any variations that fall in this list.
    /// </summary>
    public IEnumerable<int> VariationIds => _variations.Select(e => e.Id);

    public void AddExcludeExercises(IEnumerable<Exercise>? exercises)
    {
        if (exercises != null)
        {
            _exercises.AddRange(exercises);
        }
    }

    public void AddExcludeVariations(IEnumerable<Variation>? variations)
    {
        if (variations != null)
        {
            _variations.AddRange(variations);
        }
    }
}
