using FitnessTracker.Entities;
using FitnessTracker.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Data.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            
            var user = await _context.Users.SingleOrDefaultAsync(user=> user.Username == username);

            return user;
            
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public void UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
        }
    }
}
