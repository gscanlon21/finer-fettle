﻿using FinerFettle.Web.Models.Exercise;
using FinerFettle.Web.Models.Newsletter;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace FinerFettle.Web.Models.User
{
    /// <summary>
    /// User who signed up for the newsletter.
    /// </summary>
    [Table("user"), Comment("User who signed up for the newsletter")]
    [Index(nameof(Email), IsUnique = true)]
    [DebuggerDisplay("Email = {Email}, Disabled = {Disabled}")]
    public class User
    {
        public User() { }

        public User(string email, bool acceptedTerms)
        {
            Email = email.Trim();
            AcceptedTerms = acceptedTerms;
        }

        /// <summary>
        /// What progression level the user will start at if they just signed up and have no progression data
        /// </summary>
        [NotMapped]
        private const int StartingProgressionLevel = 50;

        [NotMapped]
        public static readonly string DemoUser = "demo@test.finerfettle.com";

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }

        [Required]
        public string Email { get; init; } = null!;

        [Required]
        public bool AcceptedTerms { get; init; }

        public string? DisabledReason { get; set; } = null;

        [NotMapped]
        public bool Disabled => DisabledReason != null;

        /// <summary>
        /// Pick weighted variations over calisthenics if available
        /// </summary>
        [Required]
        public bool PrefersWeights { get; set; }

        /// <summary>
        /// Don't strengthen this muscle group, but do show recovery variations for exercises
        /// </summary>
        public MuscleGroups RecoveryMuscle { get; set; }

        /// <summary>
        /// Include a section to boost a specific sports performance
        /// </summary>
        public SportsFocus SportsFocus { get; set; }

        [Required]
        public RestDays RestDays { get; set; } = RestDays.None;

        [Required]
        public DateOnly CreatedDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

        [Required]
        public StrengtheningPreference StrengtheningPreference { get; set; } = StrengtheningPreference.Obtain;

        [Required]
        public Verbosity EmailVerbosity { get; set; } = Verbosity.Normal;

        public DateOnly? LastActive { get; set; } = null;

        [Required]
        public ICollection<UserEquipment> UserEquipments { get; set; } = new List<UserEquipment>();

        [Required]
        public ICollection<UserToken> UserTokens { get; set; } = new List<UserToken>();

        [InverseProperty(nameof(UserExercise.User))]
        public virtual ICollection<UserExercise> UserExercises { get; set; } = default!;

        [InverseProperty(nameof(Newsletter.Newsletter.User))]
        public virtual ICollection<Newsletter.Newsletter> Newsletters { get; set; } = default!;

        [NotMapped]
        public IEnumerable<int> EquipmentIds => UserEquipments.Select(e => e.EquipmentId) ?? new List<int>();

        [NotMapped]
        public double AverageProgression => UserExercises.Any() ? UserExercises.Average(p => p.Progression) : StartingProgressionLevel;

        /// <summary>
        /// Sets Token to a new unique token string for authentication.
        /// </summary>
        public UserToken GetNewToken()
        {
            return new UserToken(Id);
        }
    }
}
