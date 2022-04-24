using FitnessTracker.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FitnessTracker.Entities
{
    public class WorkoutExercise
    {
        [Key]
        [JsonIgnore]
        public int UserWorkoutId { get; set; }
        [Key]
        [JsonIgnore]
        public int ExerciseId { get; set; }

        public virtual Exercise Exercise { get; set; }
        [JsonIgnore]
        public virtual UserWorkout UserWorkout { get; set; }

        public int Reps { get; set; }
        public int Sets { get; set; } = 3;
        public decimal Weight { get; set; }
    }
}
