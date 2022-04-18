using FitnessTracker.Entities;
using FitnessTracker.Interfaces;

namespace FitnessTracker.Data.Repos
{
    public class UserWorkoutRepository : BaseRepository<UserWorkout>, IUserWorkout
    {
        private readonly DataContext _dataContext;

        public UserWorkoutRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

    }
}
