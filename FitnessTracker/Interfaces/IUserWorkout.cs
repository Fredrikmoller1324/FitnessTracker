using FitnessTracker.Entities;

namespace FitnessTracker.Interfaces
{
    public interface IUserWorkout
    {
        Task AddUserWorkoutAsync(UserWorkout userWorkout);

        Task<IEnumerable<UserWorkout>> GetUserWorkoustAsync();

        Task<IEnumerable<UserWorkout>> GetUserWorkoutsByUserId(int userId);
    }
}
