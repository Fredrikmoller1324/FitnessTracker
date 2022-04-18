namespace FitnessTracker.Entities.DTOs
{
    public class WorkoutExerciseDTO
    {
        public int ExerciseId { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; } = 3;
        public decimal Weight { get; set; }
    }
}
