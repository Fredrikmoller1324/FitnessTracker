namespace FitnessTracker.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IUserWorkout UserWorkout { get; }
        IWorkoutExercise WorkoutExercise { get; }
        IExerciseRepository Exercise { get; }

        Task<bool> Complete();
        bool HasChanges();
    }
}
