namespace FitnessTracker.Entities.DTOs
{
    public class UserWorkoutDTO
    {

        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public int TimeTaken { get; set; }
        public List<WorkoutExercise> WorkoutExercises { get; set; }
    }
}
