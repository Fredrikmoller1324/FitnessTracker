using FitnessTracker.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FitnessTracker.Entities
{
    public class Exercise : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [JsonIgnore]
        public List<ExerciseCategory> ExerciseCategories { get; set; }
        [JsonIgnore]
        public virtual List<WorkoutExercise> WorkoutExercises { get; set; }

    }
}
