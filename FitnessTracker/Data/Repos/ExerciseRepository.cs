using FitnessTracker.Entities;
using FitnessTracker.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Data.Repos
{
    public class ExerciseRepository : BaseRepository<Exercise>, IExerciseRepository
    {

        private readonly DataContext _context;
        public ExerciseRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Exercise> GetExerciseByName(string exerciseName)
        {
            
            var exercise =  await _context.Exercises.Include(x=>x.ExerciseCategories).FirstOrDefaultAsync(e=>e.Name == exerciseName);

            if (exercise == null) throw new KeyNotFoundException($"Exercise with name '{exerciseName}' does not exist");

            return exercise;
        }
    }
}
