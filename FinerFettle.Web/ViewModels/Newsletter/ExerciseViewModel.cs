﻿using FinerFettle.Web.Data;
using FinerFettle.Web.Entities.Exercise;
using FinerFettle.Web.Entities.User;
using FinerFettle.Web.Models.Exercise;
using FinerFettle.Web.Models.Newsletter;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace FinerFettle.Web.ViewModels.Newsletter
{
    [DebuggerDisplay("{Variation,nq}: {Theme}, {IntensityLevel}")]
    public class ExerciseViewModel : 
        IQueryFiltersSportsFocus, 
        IQueryFiltersExerciseType, 
        IQueryFiltersIntensityLevel,
        IQueryFiltersMuscleContractions,
        IQueryFiltersRecoveryMuscle,
        IQueryFiltersShowCore
    {
        public ExerciseViewModel(Entities.User.User? user, Entities.Exercise.Exercise exercise, Variation variation, ExerciseVariation exerciseVariation, IntensityLevel? intensityLevel, ExerciseTheme theme)
        {
            Exercise = exercise;
            Variation = variation;
            ExerciseVariation = exerciseVariation;
            IntensityLevel = intensityLevel;
            Theme = theme;

            if (user != null)
            {
                Verbosity = user.EmailVerbosity;
            }
            else
            {
                Verbosity = Verbosity.Debug;
            }
        }

        public ExerciseViewModel(Entities.User.User? user, Entities.Exercise.Exercise exercise, Variation variation, ExerciseVariation exerciseVariation, IntensityLevel? intensityLevel, ExerciseTheme Theme, string token) 
            : this(user, exercise, variation, exerciseVariation, intensityLevel, Theme)
        {
            User = user != null ? new User.UserNewsletterViewModel(user, token) : null;
        }

        public ExerciseViewModel(ExerciseQueryBuilder.QueryResults result, ExerciseTheme Theme) 
            : this(result.User, result.Exercise, result.Variation, result.ExerciseVariation, result.IntensityLevel, Theme) { }

        public ExerciseViewModel(ExerciseQueryBuilder.QueryResults result, ExerciseTheme Theme, string token) 
            : this(result.User, result.Exercise, result.Variation, result.ExerciseVariation, result.IntensityLevel, Theme, token) { }

        /// <summary>
        /// Is this exercise a warmup/cooldown or main exercise? Really the theme of the exercise view.
        /// </summary>
        public ExerciseTheme Theme { get; set; }

        public IntensityLevel? IntensityLevel { get; private init; }

        public Entities.Exercise.Exercise Exercise { get; private init; } = null!;

        public Variation Variation { get; private init; } = null!;

        public ExerciseVariation ExerciseVariation { get; private init; } = null!;

        public User.UserNewsletterViewModel? User { get; private init; }

        public UserExercise? UserExercise { get; set; }
        
        public bool HasLowerProgressionVariation { get; set; }
        public bool HasHigherProgressionVariation { get; set; }

        [UIHint("Proficiency")]
        public IList<ProficiencyViewModel> Proficiencies => Variation.Intensities
            .Where(intensity => intensity.IntensityLevel == IntensityLevel || IntensityLevel == null)
            .OrderBy(intensity => intensity.IntensityLevel)
            .Select(intensity => new ProficiencyViewModel(intensity) { ShowName = IntensityLevel == null })
            .ToList();

        /// <summary>
        /// How much detail to show of the exercise?
        /// </summary>
        public Verbosity Verbosity { get; set; } = Verbosity.Normal;

        /// <summary>
        /// Should hide detail not shown in the landing page demo?
        /// </summary>
        public bool Demo => User != null && User.Email == Entities.User.User.DemoUser;

        /// <summary>
        /// Should hide detail not shown in the landing page demo?
        /// </summary>
        public bool Debug => User != null && User.Email == Entities.User.User.DebugUser;

        /// <summary>
        /// User is null when the exercise is loaded on the site, not in an email newsletter.
        /// 
        /// Emails don't support scripts.
        /// </summary>
        public bool AllowScripting => User == null;
    }
}
