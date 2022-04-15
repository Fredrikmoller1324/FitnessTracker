using FitnessTracker.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Entities
{
    public class WorkoutExercise : BaseEntity
    {
        [Key]
        public int UserWorkoutId { get; set; }
        [Key]
        public int ExerciseId { get; set; }

        public virtual Exercise Exercise { get; set; }
        public virtual UserWorkout UserWorkout { get; set; }

        public int Reps { get; set; }
        public int Sets { get; set; } = 3;
        public decimal Weight { get; set; }
    }
}
