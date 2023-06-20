﻿using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DisabledReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipment", x => x.Id);
                },
                comment: "Equipment used in an exercise");

            migrationBuilder.CreateTable(
                name: "exercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Proficiency = table.Column<int>(type: "integer", nullable: false),
                    Groups = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    DisabledReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercise", x => x.Id);
                },
                comment: "Exercises listed on the website");

            migrationBuilder.CreateTable(
                name: "footnote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Note = table.Column<string>(type: "text", nullable: false),
                    Source = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_footnote", x => x.Id);
                },
                comment: "Sage advice");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    AcceptedTerms = table.Column<bool>(type: "boolean", nullable: false),
                    ShowStaticImages = table.Column<bool>(type: "boolean", nullable: false),
                    SendMobilityWorkouts = table.Column<bool>(type: "boolean", nullable: false),
                    SeasonedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    FootnoteType = table.Column<int>(type: "integer", nullable: false),
                    PrehabFocus = table.Column<int>(type: "integer", nullable: false),
                    MobilityMuscles = table.Column<int>(type: "integer", nullable: false),
                    RehabFocus = table.Column<int>(type: "integer", nullable: false),
                    SportsFocus = table.Column<int>(type: "integer", nullable: false),
                    SendDays = table.Column<int>(type: "integer", nullable: false),
                    SendHour = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IntensityLevel = table.Column<int>(type: "integer", nullable: false),
                    Frequency = table.Column<int>(type: "integer", nullable: false),
                    DeloadAfterEveryXWeeks = table.Column<int>(type: "integer", nullable: false),
                    RefreshFunctionalEveryXWeeks = table.Column<int>(type: "integer", nullable: false),
                    RefreshAccessoryEveryXWeeks = table.Column<int>(type: "integer", nullable: false),
                    EmailVerbosity = table.Column<int>(type: "integer", nullable: false),
                    LastActive = table.Column<DateOnly>(type: "date", nullable: true),
                    DisabledReason = table.Column<string>(type: "text", nullable: true),
                    Features = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                },
                comment: "User who signed up for the newsletter");

            migrationBuilder.CreateTable(
                name: "exercise_prerequisite",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(type: "integer", nullable: false),
                    PrerequisiteExerciseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercise_prerequisite", x => new { x.ExerciseId, x.PrerequisiteExerciseId });
                    table.ForeignKey(
                        name: "FK_exercise_prerequisite_exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_exercise_prerequisite_exercise_PrerequisiteExerciseId",
                        column: x => x.PrerequisiteExerciseId,
                        principalTable: "exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Pre-requisite exercises for other exercises");

            migrationBuilder.CreateTable(
                name: "newsletter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    NewsletterRotation_Id = table.Column<int>(type: "integer", nullable: false),
                    NewsletterRotation_MuscleGroups = table.Column<int>(type: "integer", nullable: false),
                    NewsletterRotation_MovementPatterns = table.Column<int>(type: "integer", nullable: false),
                    Frequency = table.Column<int>(type: "integer", nullable: false),
                    IsDeloadWeek = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_newsletter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_newsletter_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "A day's workout routine");

            migrationBuilder.CreateTable(
                name: "user_equipment",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_equipment", x => new { x.UserId, x.EquipmentId });
                    table.ForeignKey(
                        name: "FK_user_equipment_equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_equipment_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_exercise",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ExerciseId = table.Column<int>(type: "integer", nullable: false),
                    Progression = table.Column<int>(type: "integer", nullable: false),
                    Ignore = table.Column<bool>(type: "boolean", nullable: false),
                    LastSeen = table.Column<DateOnly>(type: "date", nullable: false),
                    RefreshAfter = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_exercise", x => new { x.UserId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_user_exercise_exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_exercise_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User's progression level of an exercise");

            migrationBuilder.CreateTable(
                name: "user_frequency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Rotation_Id = table.Column<int>(type: "integer", nullable: false),
                    Rotation_MuscleGroups = table.Column<int>(type: "integer", nullable: false),
                    Rotation_MovementPatterns = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_frequency", x => new { x.UserId, x.Id });
                    table.ForeignKey(
                        name: "FK_user_frequency_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_muscle",
                columns: table => new
                {
                    MuscleGroup = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Start = table.Column<int>(type: "integer", nullable: false),
                    End = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_muscle", x => new { x.UserId, x.MuscleGroup });
                    table.ForeignKey(
                        name: "FK_user_muscle_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_token",
                columns: table => new
                {
                    Token = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Expires = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_token", x => new { x.UserId, x.Token });
                    table.ForeignKey(
                        name: "FK_user_token_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Auth tokens for a user");

            migrationBuilder.CreateTable(
                name: "exercise_variation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Progression_Min = table.Column<int>(type: "integer", nullable: true),
                    Progression_Max = table.Column<int>(type: "integer", nullable: true),
                    ExerciseType = table.Column<int>(type: "integer", nullable: false),
                    SportsFocus = table.Column<int>(type: "integer", nullable: false),
                    DisabledReason = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    ExerciseId = table.Column<int>(type: "integer", nullable: false),
                    VariationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercise_variation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_exercise_variation_exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Variation progressions for an exercise track");

            migrationBuilder.CreateTable(
                name: "newsletter_exercise_variation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NewsletterId = table.Column<int>(type: "integer", nullable: false),
                    ExerciseVariationId = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Section = table.Column<int>(type: "integer", nullable: false),
                    IntensityLevel = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_newsletter_exercise_variation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_newsletter_exercise_variation_exercise_variation_ExerciseVa~",
                        column: x => x.ExerciseVariationId,
                        principalTable: "exercise_variation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_newsletter_exercise_variation_newsletter_NewsletterId",
                        column: x => x.NewsletterId,
                        principalTable: "newsletter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "A day's workout routine");

            migrationBuilder.CreateTable(
                name: "user_exercise_variation",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ExerciseVariationId = table.Column<int>(type: "integer", nullable: false),
                    LastSeen = table.Column<DateOnly>(type: "date", nullable: false),
                    RefreshAfter = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_exercise_variation", x => new { x.UserId, x.ExerciseVariationId });
                    table.ForeignKey(
                        name: "FK_user_exercise_variation_exercise_variation_ExerciseVariatio~",
                        column: x => x.ExerciseVariationId,
                        principalTable: "exercise_variation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_exercise_variation_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User's progression level of an exercise variation");

            migrationBuilder.CreateTable(
                name: "instruction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Link = table.Column<string>(type: "text", nullable: true),
                    DisabledReason = table.Column<string>(type: "text", nullable: true),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
                    VariationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instruction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_instruction_instruction_ParentId",
                        column: x => x.ParentId,
                        principalTable: "instruction",
                        principalColumn: "Id");
                },
                comment: "Equipment that can be switched out for one another");

            migrationBuilder.CreateTable(
                name: "instruction_equipment",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(type: "integer", nullable: false),
                    InstructionsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instruction_equipment", x => new { x.EquipmentId, x.InstructionsId });
                    table.ForeignKey(
                        name: "FK_instruction_equipment_equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_instruction_equipment_instruction_InstructionsId",
                        column: x => x.InstructionsId,
                        principalTable: "instruction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "instruction_location",
                columns: table => new
                {
                    Location = table.Column<int>(type: "integer", nullable: false),
                    InstructionId = table.Column<int>(type: "integer", nullable: false),
                    Link = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instruction_location", x => new { x.Location, x.InstructionId });
                    table.ForeignKey(
                        name: "FK_instruction_location_instruction_InstructionId",
                        column: x => x.InstructionId,
                        principalTable: "instruction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Instructions that can be switched out for one another");

            migrationBuilder.CreateTable(
                name: "variation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StaticImage = table.Column<string>(type: "text", nullable: false),
                    AnimatedImage = table.Column<string>(type: "text", nullable: true),
                    Unilateral = table.Column<bool>(type: "boolean", nullable: false),
                    UseCaution = table.Column<bool>(type: "boolean", nullable: false),
                    AntiGravity = table.Column<bool>(type: "boolean", nullable: false),
                    IsWeighted = table.Column<bool>(type: "boolean", nullable: false),
                    MuscleContractions = table.Column<int>(type: "integer", nullable: false),
                    MuscleMovement = table.Column<int>(type: "integer", nullable: false),
                    MovementPattern = table.Column<int>(type: "integer", nullable: false),
                    ExerciseFocus = table.Column<int>(type: "integer", nullable: false),
                    MobilityJoints = table.Column<int>(type: "integer", nullable: false),
                    StrengthMuscles = table.Column<int>(type: "integer", nullable: false),
                    StretchMuscles = table.Column<int>(type: "integer", nullable: false),
                    SecondaryMuscles = table.Column<int>(type: "integer", nullable: false),
                    DisabledReason = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    DefaultInstructionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_variation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_variation_instruction_DefaultInstructionId",
                        column: x => x.DefaultInstructionId,
                        principalTable: "instruction",
                        principalColumn: "Id");
                },
                comment: "Variations of exercises");

            migrationBuilder.CreateTable(
                name: "intensity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DisabledReason = table.Column<string>(type: "text", nullable: true),
                    Proficiency_MinSecs = table.Column<int>(type: "integer", nullable: true),
                    Proficiency_MaxSecs = table.Column<int>(type: "integer", nullable: true),
                    Proficiency_MinReps = table.Column<int>(type: "integer", nullable: true),
                    Proficiency_MaxReps = table.Column<int>(type: "integer", nullable: true),
                    Proficiency_Sets = table.Column<int>(type: "integer", nullable: true),
                    VariationId = table.Column<int>(type: "integer", nullable: false),
                    IntensityLevel = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_intensity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_intensity_variation_VariationId",
                        column: x => x.VariationId,
                        principalTable: "variation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Intensity level of an exercise variation per user's strengthing preference");

            migrationBuilder.CreateTable(
                name: "user_variation",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    VariationId = table.Column<int>(type: "integer", nullable: false),
                    Ignore = table.Column<bool>(type: "boolean", nullable: false),
                    Pounds = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_variation", x => new { x.UserId, x.VariationId });
                    table.ForeignKey(
                        name: "FK_user_variation_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_variation_variation_VariationId",
                        column: x => x.VariationId,
                        principalTable: "variation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User's intensity stats");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_prerequisite_PrerequisiteExerciseId",
                table: "exercise_prerequisite",
                column: "PrerequisiteExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_variation_ExerciseId_VariationId",
                table: "exercise_variation",
                columns: new[] { "ExerciseId", "VariationId" });

            migrationBuilder.CreateIndex(
                name: "IX_exercise_variation_VariationId",
                table: "exercise_variation",
                column: "VariationId");

            migrationBuilder.CreateIndex(
                name: "IX_instruction_ParentId",
                table: "instruction",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_instruction_VariationId",
                table: "instruction",
                column: "VariationId");

            migrationBuilder.CreateIndex(
                name: "IX_instruction_equipment_InstructionsId",
                table: "instruction_equipment",
                column: "InstructionsId");

            migrationBuilder.CreateIndex(
                name: "IX_instruction_location_InstructionId",
                table: "instruction_location",
                column: "InstructionId");

            migrationBuilder.CreateIndex(
                name: "IX_intensity_VariationId",
                table: "intensity",
                column: "VariationId");

            migrationBuilder.CreateIndex(
                name: "IX_newsletter_UserId",
                table: "newsletter",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_newsletter_exercise_variation_ExerciseVariationId",
                table: "newsletter_exercise_variation",
                column: "ExerciseVariationId");

            migrationBuilder.CreateIndex(
                name: "IX_newsletter_exercise_variation_NewsletterId",
                table: "newsletter_exercise_variation",
                column: "NewsletterId");

            migrationBuilder.CreateIndex(
                name: "IX_user_Email",
                table: "user",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_equipment_EquipmentId",
                table: "user_equipment",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_user_exercise_ExerciseId",
                table: "user_exercise",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_user_exercise_variation_ExerciseVariationId",
                table: "user_exercise_variation",
                column: "ExerciseVariationId");

            migrationBuilder.CreateIndex(
                name: "IX_user_variation_VariationId",
                table: "user_variation",
                column: "VariationId");

            migrationBuilder.CreateIndex(
                name: "IX_variation_DefaultInstructionId",
                table: "variation",
                column: "DefaultInstructionId");

            migrationBuilder.AddForeignKey(
                name: "FK_exercise_variation_variation_VariationId",
                table: "exercise_variation",
                column: "VariationId",
                principalTable: "variation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_instruction_variation_VariationId",
                table: "instruction",
                column: "VariationId",
                principalTable: "variation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_instruction_variation_VariationId",
                table: "instruction");

            migrationBuilder.DropTable(
                name: "exercise_prerequisite");

            migrationBuilder.DropTable(
                name: "footnote");

            migrationBuilder.DropTable(
                name: "instruction_equipment");

            migrationBuilder.DropTable(
                name: "instruction_location");

            migrationBuilder.DropTable(
                name: "intensity");

            migrationBuilder.DropTable(
                name: "newsletter_exercise_variation");

            migrationBuilder.DropTable(
                name: "user_equipment");

            migrationBuilder.DropTable(
                name: "user_exercise");

            migrationBuilder.DropTable(
                name: "user_exercise_variation");

            migrationBuilder.DropTable(
                name: "user_frequency");

            migrationBuilder.DropTable(
                name: "user_muscle");

            migrationBuilder.DropTable(
                name: "user_token");

            migrationBuilder.DropTable(
                name: "user_variation");

            migrationBuilder.DropTable(
                name: "newsletter");

            migrationBuilder.DropTable(
                name: "equipment");

            migrationBuilder.DropTable(
                name: "exercise_variation");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "exercise");

            migrationBuilder.DropTable(
                name: "variation");

            migrationBuilder.DropTable(
                name: "instruction");
        }
    }
}
