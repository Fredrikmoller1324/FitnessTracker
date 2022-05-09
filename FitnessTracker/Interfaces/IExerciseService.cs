using FitnessTracker.Entities;
using FitnessTracker.Entities.DTOs;

namespace FitnessTracker.Interfaces
{
    public interface IExerciseService
    {
        Task<IEnumerable<ExerciseDTO>> GetAllExercisesAsync();

        Task<ExerciseDTO> GetByNameAsync(string exerciseName);

        Task<Exercise> CreateExerciseAsync(ExerciseDTO exercise);

        Task<Exercise> DeleteExerciseAsync(int key);

        Task<IEnumerable<ExerciseCategory>> GetExerciseCategoriesAsync();
    }
}
