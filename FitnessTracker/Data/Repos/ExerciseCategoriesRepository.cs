using FitnessTracker.Entities;
using FitnessTracker.Interfaces;

namespace FitnessTracker.Data.Repos
{
    public class ExerciseCategoriesRepository : BaseRepository<ExerciseCategory>, IExerciseCategoriesRepository
    {

        private readonly DataContext _context;
        public ExerciseCategoriesRepository(DataContext context) : base(context)
        {
            _context = context;
        }

    }
}
