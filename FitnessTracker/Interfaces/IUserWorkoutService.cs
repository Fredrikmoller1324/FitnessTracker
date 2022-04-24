using FitnessTracker.Entities;
using FitnessTracker.Entities.DTOs;

namespace FitnessTracker.Interfaces
{
    public interface IUserWorkoutService
    {
        Task CreateUserWorkoutAsync(UserWorkoutDTO userWorkout,int userId);

        Task<IEnumerable<UserWorkoutDTO>> GetAllUserWorkouts(int userId);

        Task<IEnumerable<UserWorkoutDTO>> GetAllSpecificUserWorkoutsByName(int userId, string name);
    }
}
