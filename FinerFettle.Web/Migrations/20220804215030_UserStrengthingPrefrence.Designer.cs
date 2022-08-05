﻿// <auto-generated />
using System;
using FinerFettle.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinerFettle.Web.Migrations
{
    [DbContext(typeof(CoreContext))]
    [Migration("20220804215030_UserStrengthingPrefrence")]
    partial class UserStrengthingPrefrence
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EquipmentEquipmentGroup", b =>
                {
                    b.Property<int>("EquipmentGroupsId")
                        .HasColumnType("integer");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("integer");

                    b.HasKey("EquipmentGroupsId", "EquipmentId");

                    b.HasIndex("EquipmentId");

                    b.ToTable("EquipmentEquipmentGroup");
                });

            modelBuilder.Entity("EquipmentGroupVariation", b =>
                {
                    b.Property<int>("EquipmentGroupsId")
                        .HasColumnType("integer");

                    b.Property<int>("VariationsId")
                        .HasColumnType("integer");

                    b.HasKey("EquipmentGroupsId", "VariationsId");

                    b.HasIndex("VariationsId");

                    b.ToTable("EquipmentGroupVariation");
                });

            modelBuilder.Entity("FinerFettle.Web.Models.Exercise.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Equipment");

                    b.HasComment("Equipment used in an exercise");
                });

            modelBuilder.Entity("FinerFettle.Web.Models.Exercise.EquipmentGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("EquipmentGroup");

                    b.HasComment("Equipment that can be switched out for one another");
                });

            modelBuilder.Entity("FinerFettle.Web.Models.Exercise.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ExerciseType")
                        .HasColumnType("integer");

                    b.Property<int>("Muscles")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Exercise");

                    b.HasComment("Exercises listed on the website");
                });

            modelBuilder.Entity("FinerFettle.Web.Models.Exercise.Intensity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("IntensityLevel")
                        .HasColumnType("integer");

                    b.Property<int?>("MaxProgression")
                        .HasColumnType("integer");

                    b.Property<int?>("MinProgression")
                        .HasColumnType("integer");

                    b.Property<int>("VariationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("VariationId");

                    b.ToTable("Intensity");

                    b.HasComment("Intensity level of an exercise variation");
                });

            modelBuilder.Entity("FinerFettle.Web.Models.Exercise.Variation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Enabled")
                        .HasColumnType("boolean");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("integer");

                    b.Property<string>("Instruction")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MuscleContractions")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("Variation");

                    b.HasComment("Progressions of an exercise");
                });

            modelBuilder.Entity("FinerFettle.Web.Models.Footnotes.Footnote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Footnote");

                    b.HasComment("Sage advice");
                });

            modelBuilder.Entity("FinerFettle.Web.Models.Newsletter.Newsletter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Newsletter");

                    b.HasComment("A day's workout routine");
                });

            modelBuilder.Entity("FinerFettle.Web.Models.User.EquipmentUser", b =>
                {
                    b.Property<int>("EquipmentId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("EquipmentId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("EquipmentUser");
                });

            modelBuilder.Entity("FinerFettle.Web.Models.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("NeedsRest")
                        .HasColumnType("boolean");

                    b.Property<bool>("OverMinimumAge")
                        .HasColumnType("boolean");

                    b.Property<int?>("Progression")
                        .HasColumnType("integer");

                    b.Property<int>("RestDays")
                        .HasColumnType("integer");

                    b.Property<int>("StrengtheningPreference")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasComment("User who signed up for the newsletter");
                });

            modelBuilder.Entity("EquipmentEquipmentGroup", b =>
                {
                    b.HasOne("FinerFettle.Web.Models.Exercise.EquipmentGroup", null)
                        .WithMany()
                        .HasForeignKey("EquipmentGroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinerFettle.Web.Models.Exercise.Equipment", null)
                        .WithMany()
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EquipmentGroupVariation", b =>
                {
                    b.HasOne("FinerFettle.Web.Models.Exercise.EquipmentGroup", null)
                        .WithMany()
                        .HasForeignKey("EquipmentGroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinerFettle.Web.Models.Exercise.Variation", null)
                        .WithMany()
                        .HasForeignKey("VariationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FinerFettle.Web.Models.Exercise.Intensity", b =>
                {
                    b.HasOne("FinerFettle.Web.Models.Exercise.Variation", "Variation")
                        .WithMany("Intensities")
                        .HasForeignKey("VariationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("FinerFettle.Web.Models.Exercise.Proficiency", "Proficiency", b1 =>
                        {
                            b1.Property<int>("IntensityId")
                                .HasColumnType("integer");

                            b1.Property<int?>("Reps")
                                .HasColumnType("integer");

                            b1.Property<int?>("Secs")
                                .HasColumnType("integer");

                            b1.Property<int?>("Sets")
                                .HasColumnType("integer");

                            b1.HasKey("IntensityId");

                            b1.ToTable("Intensity");

                            b1.WithOwner()
                                .HasForeignKey("IntensityId");
                        });

                    b.Navigation("Proficiency")
                        .IsRequired();

                    b.Navigation("Variation");
                });

            modelBuilder.Entity("FinerFettle.Web.Models.Exercise.Variation", b =>
                {
                    b.HasOne("FinerFettle.Web.Models.Exercise.Exercise", "Exercise")
                        .WithMany("Variations")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("FinerFettle.Web.Models.Newsletter.Newsletter", b =>
                {
                    b.HasOne("FinerFettle.Web.Models.User.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.OwnsOne("FinerFettle.Web.Models.Exercise.ExerciseRotaion", "ExerciseRotation", b1 =>
                        {
                            b1.Property<int>("NewsletterId")
                                .HasColumnType("integer");

                            b1.Property<int>("ExerciseType")
                                .HasColumnType("integer");

                            b1.Property<int>("MuscleGroups")
                                .HasColumnType("integer");

                            b1.HasKey("NewsletterId");

                            b1.ToTable("Newsletter");

                            b1.WithOwner()
                                .HasForeignKey("NewsletterId");
                        });

                    b.Navigation("ExerciseRotation")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FinerFettle.Web.Models.User.EquipmentUser", b =>
                {
                    b.HasOne("FinerFettle.Web.Models.Exercise.Equipment", "Equipment")
                        .WithMany("EquipmentUsers")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinerFettle.Web.Models.User.User", "User")
                        .WithMany("EquipmentUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FinerFettle.Web.Models.Exercise.Equipment", b =>
                {
                    b.Navigation("EquipmentUsers");
                });

            modelBuilder.Entity("FinerFettle.Web.Models.Exercise.Exercise", b =>
                {
                    b.Navigation("Variations");
                });

            modelBuilder.Entity("FinerFettle.Web.Models.Exercise.Variation", b =>
                {
                    b.Navigation("Intensities");
                });

            modelBuilder.Entity("FinerFettle.Web.Models.User.User", b =>
                {
                    b.Navigation("EquipmentUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
