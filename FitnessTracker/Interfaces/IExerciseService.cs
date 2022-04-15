using FitnessTracker.Entities;
using FitnessTracker.Entities.DTOs;

namespace FitnessTracker.Interfaces
{
    public interface IExerciseService
    {
        Task<IEnumerable<ExerciseDTO>> GetAllExercises();
    }
}
