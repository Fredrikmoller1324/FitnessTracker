namespace FitnessTracker.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IUserWorkout UserWorkout { get; }
        IWorkoutExercise WorkoutExercise { get; }
        IExerciseRepository ExerciseRepository { get; }

        Task<bool> CompleteAsync();
        bool HasChangesAsync();
    }
}
