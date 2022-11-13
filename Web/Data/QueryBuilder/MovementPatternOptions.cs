﻿using Web.Models.Exercise;

namespace Web.Data.QueryBuilder;

public class MovementPatternOptions
{
    /// <summary>
    ///     If true, chooses one variation that works each unique movement pattern.
    ///     If false, chooses all variations that work any of the movement patterns.
    /// </summary>
    public bool IsUnique { get; set; } = false;

    public MovementPatternOptions() { }

    public MovementPatternOptions(MovementPattern movementPatterns)
    {
        MovementPatterns = movementPatterns;
    }

    public MovementPattern MovementPatterns { get; } = MovementPattern.None;
}