using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Entities
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ExerciseCategory> ExerciseCategories { get; set; }
        public virtual List<WorkoutExercise> WorkoutExercises { get; set; }

    }
}
