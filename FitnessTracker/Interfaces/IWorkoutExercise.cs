using FitnessTracker.Entities;

namespace FitnessTracker.Interfaces
{
    public interface IWorkoutExercise
    {
        Task AddAsync(WorkoutExercise workoutExercise);
    }
}
