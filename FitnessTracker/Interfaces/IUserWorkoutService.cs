using FitnessTracker.Entities.DTOs;

namespace FitnessTracker.Interfaces
{
    public interface IUserWorkoutService
    {
        Task CreateUserWorkoutAsync(UserWorkoutDTO userWorkout,int userId);
    }
}
