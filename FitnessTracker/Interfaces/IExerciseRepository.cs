using FitnessTracker.Entities;
using FitnessTracker.Interfaces;

namespace FitnessTracker.Interfaces
{
    public interface IExerciseRepository : IGeneric<Exercise>
    {
        Task<Exercise> GetExerciseByName(string exerciseName);
    }
}
