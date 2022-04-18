using FitnessTracker.Interfaces;

namespace FitnessTracker.Entities
{
    public class UserWorkout : BaseEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int TimeTaken { get; set; }
        public virtual List<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
    }
}
