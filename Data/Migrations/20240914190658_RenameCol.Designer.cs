﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(CoreContext))]
    [Migration("20240914190658_RenameCol")]
    partial class RenameCol
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.3.24172.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Data.Entities.Equipment.Instruction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("DisabledReason")
                        .HasColumnType("text");

                    b.Property<int>("Equipment")
                        .HasColumnType("integer");

                    b.Property<string>("Link")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<int?>("Order")
                        .HasColumnType("integer");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.Property<int>("VariationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("VariationId");

                    b.ToTable("instruction", t =>
                        {
                            t.HasComment("Equipment that can be switched out for one another");
                        });
                });

            modelBuilder.Entity("Data.Entities.Exercise.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("DisabledReason")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<int>("SkillType")
                        .HasColumnType("integer");

                    b.Property<int>("Skills")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("exercise", t =>
                        {
                            t.HasComment("Exercises listed on the website");
                        });
                });

            modelBuilder.Entity("Data.Entities.Exercise.ExercisePrerequisite", b =>
                {
                    b.Property<int>("ExerciseId")
                        .HasColumnType("integer");

                    b.Property<int>("PrerequisiteExerciseId")
                        .HasColumnType("integer");

                    b.Property<int>("Proficiency")
                        .HasColumnType("integer");

                    b.HasKey("ExerciseId", "PrerequisiteExerciseId");

                    b.HasIndex("PrerequisiteExerciseId");

                    b.ToTable("exercise_prerequisite", t =>
                        {
                            t.HasComment("Pre-requisite exercises for other exercises");
                        });
                });

            modelBuilder.Entity("Data.Entities.Exercise.Variation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AnimatedImage")
                        .HasColumnType("text");

                    b.Property<string>("DefaultInstruction")
                        .HasColumnType("text");

                    b.Property<string>("DisabledReason")
                        .HasColumnType("text");

                    b.Property<int>("ExerciseFocus")
                        .HasColumnType("integer");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsWeighted")
                        .HasColumnType("boolean");

                    b.Property<long>("MobilityJoints")
                        .HasColumnType("bigint");

                    b.Property<int>("MovementPattern")
                        .HasColumnType("integer");

                    b.Property<int>("MuscleMovement")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<bool?>("PauseReps")
                        .HasColumnType("boolean");

                    b.Property<long>("Stabilizes")
                        .HasColumnType("bigint");

                    b.Property<int>("Section")
                        .HasColumnType("integer");

                    b.Property<int>("SportsFocus")
                        .HasColumnType("integer");

                    b.Property<string>("StaticImage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Strengthens")
                        .HasColumnType("bigint");

                    b.Property<long>("Stretches")
                        .HasColumnType("bigint");

                    b.Property<bool>("Unilateral")
                        .HasColumnType("boolean");

                    b.Property<bool>("UseCaution")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("variation", t =>
                        {
                            t.HasComment("Variations of exercises");
                        });
                });

            modelBuilder.Entity("Data.Entities.Footnote.Footnote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Source")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("footnote", t =>
                        {
                            t.HasComment("Sage advice");
                        });
                });

            modelBuilder.Entity("Data.Entities.Footnote.UserFootnote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Source")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("UserLastSeen")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("user_footnote", t =>
                        {
                            t.HasComment("Sage advice");
                        });
                });

            modelBuilder.Entity("Data.Entities.Newsletter.UserEmail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("LastError")
                        .HasColumnType("text");

                    b.Property<DateTime>("SendAfter")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("SendAttempts")
                        .HasColumnType("integer");

                    b.Property<string>("SenderId")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("user_email", t =>
                        {
                            t.HasComment("A day's workout routine");
                        });
                });

            modelBuilder.Entity("Data.Entities.Newsletter.UserWorkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("Frequency")
                        .HasColumnType("integer");

                    b.Property<int>("Intensity")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeloadWeek")
                        .HasColumnType("boolean");

                    b.Property<string>("Logs")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("user_workout", t =>
                        {
                            t.HasComment("A day's workout routine");
                        });
                });

            modelBuilder.Entity("Data.Entities.Newsletter.UserWorkoutVariation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<int>("Section")
                        .HasColumnType("integer");

                    b.Property<int>("UserWorkoutId")
                        .HasColumnType("integer");

                    b.Property<int>("VariationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserWorkoutId");

                    b.HasIndex("VariationId");

                    b.ToTable("user_workout_variation", t =>
                        {
                            t.HasComment("A day's workout routine");
                        });
                });

            modelBuilder.Entity("Data.Entities.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("AcceptedTerms")
                        .HasColumnType("boolean");

                    b.Property<int>("AtLeastXUniqueMusclesPerExercise_Accessory")
                        .HasColumnType("integer");

                    b.Property<int>("AtLeastXUniqueMusclesPerExercise_Flexibility")
                        .HasColumnType("integer");

                    b.Property<int>("AtLeastXUniqueMusclesPerExercise_Mobility")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("CreatedDate")
                        .HasColumnType("date");

                    b.Property<int>("DeloadAfterXWeeks")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Equipment")
                        .HasColumnType("integer");

                    b.Property<int>("Features")
                        .HasColumnType("integer");

                    b.Property<int>("FootnoteCountBottom")
                        .HasColumnType("integer");

                    b.Property<int>("FootnoteCountTop")
                        .HasColumnType("integer");

                    b.Property<int>("FootnoteType")
                        .HasColumnType("integer");

                    b.Property<int>("Frequency")
                        .HasColumnType("integer");

                    b.Property<bool>("IgnorePrerequisites")
                        .HasColumnType("boolean");

                    b.Property<int>("ImageType")
                        .HasColumnType("integer");

                    b.Property<bool>("IncludeMobilityWorkouts")
                        .HasColumnType("boolean");

                    b.Property<int>("Intensity")
                        .HasColumnType("integer");

                    b.Property<DateOnly?>("LastActive")
                        .HasColumnType("date");

                    b.Property<string>("NewsletterDisabledReason")
                        .HasColumnType("text");

                    b.Property<long>("PrehabFocus")
                        .HasColumnType("bigint");

                    b.Property<long>("RehabFocus")
                        .HasColumnType("bigint");

                    b.Property<int>("RehabSkills")
                        .HasColumnType("integer");

                    b.Property<DateOnly?>("SeasonedDate")
                        .HasColumnType("date");

                    b.Property<int>("SendDays")
                        .HasColumnType("integer");

                    b.Property<int>("SendHour")
                        .HasColumnType("integer");

                    b.Property<int>("SportsFocus")
                        .HasColumnType("integer");

                    b.Property<int>("Verbosity")
                        .HasColumnType("integer");

                    b.Property<double>("WeightIsolationXTimesMore")
                        .HasColumnType("double precision");

                    b.Property<double>("WeightSecondaryMusclesXTimesLess")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("user", t =>
                        {
                            t.HasComment("User who signed up for the newsletter");
                        });
                });

            modelBuilder.Entity("Data.Entities.User.UserExercise", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("integer");

                    b.Property<bool>("Ignore")
                        .HasColumnType("boolean");

                    b.Property<DateOnly>("LastSeen")
                        .HasColumnType("date");

                    b.Property<DateOnly>("LastVisible")
                        .HasColumnType("date");

                    b.Property<int>("Progression")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "ExerciseId");

                    b.HasIndex("ExerciseId");

                    b.ToTable("user_exercise", t =>
                        {
                            t.HasComment("User's progression level of an exercise");
                        });
                });

            modelBuilder.Entity("Data.Entities.User.UserFrequency", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "Id");

                    b.ToTable("user_frequency");
                });

            modelBuilder.Entity("Data.Entities.User.UserMuscleFlexibility", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<long>("MuscleGroup")
                        .HasColumnType("bigint");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "MuscleGroup");

                    b.ToTable("user_muscle_flexibility");
                });

            modelBuilder.Entity("Data.Entities.User.UserMuscleMobility", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<long>("MuscleGroup")
                        .HasColumnType("bigint");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "MuscleGroup");

                    b.ToTable("user_muscle_mobility");
                });

            modelBuilder.Entity("Data.Entities.User.UserMuscleStrength", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<long>("MuscleGroup")
                        .HasColumnType("bigint");

                    b.Property<int>("End")
                        .HasColumnType("integer");

                    b.Property<int>("Start")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "MuscleGroup");

                    b.ToTable("user_muscle_strength");
                });

            modelBuilder.Entity("Data.Entities.User.UserPrehabSkill", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<long>("PrehabFocus")
                        .HasColumnType("bigint");

                    b.Property<bool>("AllRefreshed")
                        .HasColumnType("boolean");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<int>("Skills")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "PrehabFocus");

                    b.ToTable("user_prehab_skill");
                });

            modelBuilder.Entity("Data.Entities.User.UserToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Expires")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId", "Token");

                    b.ToTable("user_token", t =>
                        {
                            t.HasComment("Auth tokens for a user");
                        });
                });

            modelBuilder.Entity("Data.Entities.User.UserVariation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ignore")
                        .HasColumnType("boolean");

                    b.Property<int>("LagRefreshXWeeks")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("LastSeen")
                        .HasColumnType("date");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<int>("PadRefreshXWeeks")
                        .HasColumnType("integer");

                    b.Property<DateOnly?>("RefreshAfter")
                        .HasColumnType("date");

                    b.Property<int>("Reps")
                        .HasColumnType("integer");

                    b.Property<int>("Secs")
                        .HasColumnType("integer");

                    b.Property<int>("Section")
                        .HasColumnType("integer");

                    b.Property<int>("Sets")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("VariationId")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("VariationId");

                    b.HasIndex("UserId", "VariationId", "Section")
                        .IsUnique();

                    b.ToTable("user_variation", t =>
                        {
                            t.HasComment("User's intensity stats");
                        });
                });

            modelBuilder.Entity("Data.Entities.User.UserVariationLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("Reps")
                        .HasColumnType("integer");

                    b.Property<int>("Secs")
                        .HasColumnType("integer");

                    b.Property<int>("Sets")
                        .HasColumnType("integer");

                    b.Property<int>("UserVariationId")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserVariationId");

                    b.ToTable("user_variation_log", t =>
                        {
                            t.HasComment("User variation weight log");
                        });
                });

            modelBuilder.Entity("Data.Entities.Equipment.Instruction", b =>
                {
                    b.HasOne("Data.Entities.Equipment.Instruction", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.HasOne("Data.Entities.Exercise.Variation", "Variation")
                        .WithMany("Instructions")
                        .HasForeignKey("VariationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");

                    b.Navigation("Variation");
                });

            modelBuilder.Entity("Data.Entities.Exercise.ExercisePrerequisite", b =>
                {
                    b.HasOne("Data.Entities.Exercise.Exercise", "Exercise")
                        .WithMany("Prerequisites")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Exercise.Exercise", "PrerequisiteExercise")
                        .WithMany("Postrequisites")
                        .HasForeignKey("PrerequisiteExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("PrerequisiteExercise");
                });

            modelBuilder.Entity("Data.Entities.Exercise.Variation", b =>
                {
                    b.HasOne("Data.Entities.Exercise.Exercise", "Exercise")
                        .WithMany("Variations")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Data.Entities.Exercise.Progression", "Progression", b1 =>
                        {
                            b1.Property<int>("VariationId")
                                .HasColumnType("integer");

                            b1.Property<int?>("Max")
                                .HasColumnType("integer");

                            b1.Property<int?>("Min")
                                .HasColumnType("integer");

                            b1.HasKey("VariationId");

                            b1.ToTable("variation");

                            b1.WithOwner()
                                .HasForeignKey("VariationId");
                        });

                    b.Navigation("Exercise");

                    b.Navigation("Progression")
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.Footnote.UserFootnote", b =>
                {
                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("UserFootnotes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.Newsletter.UserEmail", b =>
                {
                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("UserEmails")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.Newsletter.UserWorkout", b =>
                {
                    b.OwnsOne("Data.Entities.Newsletter.WorkoutRotation", "Rotation", b1 =>
                        {
                            b1.Property<int>("UserWorkoutId")
                                .HasColumnType("integer");

                            b1.Property<int>("Id")
                                .HasColumnType("integer");

                            b1.Property<int>("MovementPatterns")
                                .HasColumnType("integer");

                            b1.Property<string>("MuscleGroups")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("UserWorkoutId");

                            b1.ToTable("user_workout");

                            b1.WithOwner()
                                .HasForeignKey("UserWorkoutId");
                        });

                    b.Navigation("Rotation")
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.Newsletter.UserWorkoutVariation", b =>
                {
                    b.HasOne("Data.Entities.Newsletter.UserWorkout", "UserWorkout")
                        .WithMany("UserWorkoutVariations")
                        .HasForeignKey("UserWorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Exercise.Variation", "Variation")
                        .WithMany("UserWorkoutVariations")
                        .HasForeignKey("VariationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserWorkout");

                    b.Navigation("Variation");
                });

            modelBuilder.Entity("Data.Entities.User.UserExercise", b =>
                {
                    b.HasOne("Data.Entities.Exercise.Exercise", "Exercise")
                        .WithMany("UserExercises")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("UserExercises")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.User.UserFrequency", b =>
                {
                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("UserFrequencies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Data.Entities.Newsletter.WorkoutRotation", "Rotation", b1 =>
                        {
                            b1.Property<int>("UserFrequencyUserId")
                                .HasColumnType("integer");

                            b1.Property<int>("UserFrequencyId")
                                .HasColumnType("integer");

                            b1.Property<int>("Id")
                                .HasColumnType("integer");

                            b1.Property<int>("MovementPatterns")
                                .HasColumnType("integer");

                            b1.Property<string>("MuscleGroups")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("UserFrequencyUserId", "UserFrequencyId");

                            b1.ToTable("user_frequency");

                            b1.WithOwner()
                                .HasForeignKey("UserFrequencyUserId", "UserFrequencyId");
                        });

                    b.Navigation("Rotation")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.User.UserMuscleFlexibility", b =>
                {
                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("UserMuscleFlexibilities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.User.UserMuscleMobility", b =>
                {
                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("UserMuscleMobilities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.User.UserMuscleStrength", b =>
                {
                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("UserMuscleStrengths")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.User.UserPrehabSkill", b =>
                {
                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("UserPrehabSkills")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.User.UserToken", b =>
                {
                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("UserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.User.UserVariation", b =>
                {
                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("UserVariations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Exercise.Variation", "Variation")
                        .WithMany("UserVariations")
                        .HasForeignKey("VariationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Variation");
                });

            modelBuilder.Entity("Data.Entities.User.UserVariationLog", b =>
                {
                    b.HasOne("Data.Entities.User.UserVariation", "UserVariation")
                        .WithMany("UserVariationLogs")
                        .HasForeignKey("UserVariationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserVariation");
                });

            modelBuilder.Entity("Data.Entities.Equipment.Instruction", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("Data.Entities.Exercise.Exercise", b =>
                {
                    b.Navigation("Postrequisites");

                    b.Navigation("Prerequisites");

                    b.Navigation("UserExercises");

                    b.Navigation("Variations");
                });

            modelBuilder.Entity("Data.Entities.Exercise.Variation", b =>
                {
                    b.Navigation("Instructions");

                    b.Navigation("UserVariations");

                    b.Navigation("UserWorkoutVariations");
                });

            modelBuilder.Entity("Data.Entities.Newsletter.UserWorkout", b =>
                {
                    b.Navigation("UserWorkoutVariations");
                });

            modelBuilder.Entity("Data.Entities.User.User", b =>
                {
                    b.Navigation("UserEmails");

                    b.Navigation("UserExercises");

                    b.Navigation("UserFootnotes");

                    b.Navigation("UserFrequencies");

                    b.Navigation("UserMuscleFlexibilities");

                    b.Navigation("UserMuscleMobilities");

                    b.Navigation("UserMuscleStrengths");

                    b.Navigation("UserPrehabSkills");

                    b.Navigation("UserTokens");

                    b.Navigation("UserVariations");
                });

            modelBuilder.Entity("Data.Entities.User.UserVariation", b =>
                {
                    b.Navigation("UserVariationLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
