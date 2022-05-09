using FitnessTracker.Interfaces;

namespace FitnessTracker.Data.Repos
{
    public class UnitOfWorkRepository : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWorkRepository(DataContext context)
        {
            _context = context;
        }

        public IUserWorkout UserWorkoutRepository => new UserWorkoutRepository(_context);

        public IWorkoutExercise WorkoutExercise => throw new NotImplementedException();

        public IUserRepository UserRepository => new UserRepository(_context);

        public IExerciseRepository ExerciseRepository => new ExerciseRepository(_context);

        public IExerciseCategoriesRepository ExerciseCategoriesRepository => new ExerciseCategoriesRepository(_context);

        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChangesAsync()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}
