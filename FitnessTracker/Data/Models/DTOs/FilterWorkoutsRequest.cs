using FitnessTracker.Entities;

namespace FitnessTracker.Data.Models.DTOs
{
    public class FilterWorkoutsRequest
    {
        public string WorkoutName { get; set; } = string.Empty;
        public int? ExerciseId { get; set; } = null;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;

    }
}
