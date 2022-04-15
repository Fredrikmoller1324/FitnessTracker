using FitnessTracker.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Entities
{
    public class Exercise : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ExerciseCategory> ExerciseCategories { get; set; }
        public virtual List<WorkoutExercise> WorkoutExercises { get; set; }

    }
}
