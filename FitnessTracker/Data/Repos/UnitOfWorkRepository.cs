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

        public IUserWorkout UserWorkout => throw new NotImplementedException();

        public IWorkoutExercise WorkoutExercise => throw new NotImplementedException();

        public IUserRepository UserRepository => new UserRepository(_context);

        public IExerciseRepository Exercise => new ExerciseRepository(_context);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}
