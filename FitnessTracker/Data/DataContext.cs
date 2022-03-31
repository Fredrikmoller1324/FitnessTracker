using FitnessTracker.Data.EntityConfigurations;
using FitnessTracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseCategory> ExerciseCategories { get; set; }
        public DbSet<UserWorkout> UserWorkouts { get; set; } 
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkoutExercise>()
                .HasKey(q => new
                {
                    q.UserWorkoutId,
                    q.ExerciseId
                });

            new ExerciseEntityTypeConfigurations().Configure(modelBuilder.Entity<Exercise>());
            new ExerciseCategoryEntityTypeConfigurations().Configure(modelBuilder.Entity<ExerciseCategory>());

            modelBuilder.Entity<Exercise>()
                .HasMany(left => left.ExerciseCategories)
                .WithMany(right => right.Exercises)
                .UsingEntity("ExerciseExcerciseCategory",
                right => right.HasOne(typeof(ExerciseCategory)).WithMany().HasForeignKey("ExerciseCategoryId"),
                left => left.HasOne(typeof(Exercise)).WithMany().HasForeignKey("ExerciseId"),
                join => join.ToTable("ExerciseExerciseCategories")
                );

            modelBuilder.Entity("ExerciseExcerciseCategory").HasData(
                    new { ExerciseId = 1, ExerciseCategoryId = 1},
                    new { ExerciseId = 1, ExerciseCategoryId = 2 },
                    new { ExerciseId = 1, ExerciseCategoryId = 6 },
                    new { ExerciseId = 1, ExerciseCategoryId = 7 }
                );

        }

    }
}
