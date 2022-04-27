using FitnessTracker.Entities;

namespace FitnessTracker.Interfaces
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByUsername(string username);
        void UpdateUserAsync(User user);
    }
}
