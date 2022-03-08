namespace FitnessTracker.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IUserWorkout UserWorkout { get; }
        IWorkoutExercise WorkoutExercise { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}
