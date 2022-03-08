namespace FitnessTracker.Entities
{
    public class UserWorkout
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int TimeTaken { get; set; }
        public virtual List<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
    }
}
