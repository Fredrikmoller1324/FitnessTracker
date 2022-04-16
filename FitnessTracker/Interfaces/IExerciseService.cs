using FitnessTracker.Entities;
using FitnessTracker.Entities.DTOs;

namespace FitnessTracker.Interfaces
{
    public interface IExerciseService
    {
        Task<IEnumerable<ExerciseDTO>> GetAllExercisesAsync();

        Task<ExerciseDTO> GetByNameAsync(string exerciseName);

        Task CreateExerciseAsync(ExerciseDTO exercise);

        Task DeleteExerciseAsync(int key);
    }
}
