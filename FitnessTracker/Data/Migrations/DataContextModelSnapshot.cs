﻿// <auto-generated />
using System;
using FitnessTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitnessTracker.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ExerciseExcerciseCategory", b =>
                {
                    b.Property<int>("ExerciseCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.HasKey("ExerciseCategoryId", "ExerciseId");

                    b.HasIndex("ExerciseId");

                    b.ToTable("ExerciseExerciseCategories", (string)null);

                    b.HasData(
                        new
                        {
                            ExerciseCategoryId = 1,
                            ExerciseId = 1
                        },
                        new
                        {
                            ExerciseCategoryId = 2,
                            ExerciseId = 1
                        },
                        new
                        {
                            ExerciseCategoryId = 6,
                            ExerciseId = 1
                        },
                        new
                        {
                            ExerciseCategoryId = 7,
                            ExerciseId = 1
                        });
                });

            modelBuilder.Entity("FitnessTracker.Entities.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Exercises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Squat"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Deadlift"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Bench press"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Bicep Curl"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Leg press"
                        });
                });

            modelBuilder.Entity("FitnessTracker.Entities.ExerciseCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExerciseCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Upper Back"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Lower Back"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Chest"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Biceps"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Triceps"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Legs"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Calves"
                        });
                });

            modelBuilder.Entity("FitnessTracker.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FitnessTracker.Entities.UserWorkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TimeTaken")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserWorkouts");
                });

            modelBuilder.Entity("FitnessTracker.Entities.WorkoutExercise", b =>
                {
                    b.Property<int>("UserWorkoutId")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<int>("Sets")
                        .HasColumnType("int");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("UserWorkoutId", "ExerciseId");

                    b.HasIndex("ExerciseId");

                    b.ToTable("WorkoutExercises");
                });

            modelBuilder.Entity("ExerciseExcerciseCategory", b =>
                {
                    b.HasOne("FitnessTracker.Entities.ExerciseCategory", null)
                        .WithMany()
                        .HasForeignKey("ExerciseCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessTracker.Entities.Exercise", null)
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FitnessTracker.Entities.UserWorkout", b =>
                {
                    b.HasOne("FitnessTracker.Entities.User", null)
                        .WithMany("UserWorkouts")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FitnessTracker.Entities.WorkoutExercise", b =>
                {
                    b.HasOne("FitnessTracker.Entities.Exercise", "Exercise")
                        .WithMany("WorkoutExercises")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessTracker.Entities.UserWorkout", "UserWorkout")
                        .WithMany("WorkoutExercises")
                        .HasForeignKey("UserWorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("UserWorkout");
                });

            modelBuilder.Entity("FitnessTracker.Entities.Exercise", b =>
                {
                    b.Navigation("WorkoutExercises");
                });

            modelBuilder.Entity("FitnessTracker.Entities.User", b =>
                {
                    b.Navigation("UserWorkouts");
                });

            modelBuilder.Entity("FitnessTracker.Entities.UserWorkout", b =>
                {
                    b.Navigation("WorkoutExercises");
                });
#pragma warning restore 612, 618
        }
    }
}
