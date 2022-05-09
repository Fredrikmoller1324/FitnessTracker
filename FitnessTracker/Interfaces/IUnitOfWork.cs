namespace FitnessTracker.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IUserWorkout UserWorkoutRepository { get; }
        IWorkoutExercise WorkoutExercise { get; }
        IExerciseRepository ExerciseRepository { get; }
        IExerciseCategoriesRepository ExerciseCategoriesRepository { get; }

        Task<bool> CompleteAsync();
        bool HasChangesAsync();
    }
}
