using AutoMapper;
using FitnessTracker.Entities;
using FitnessTracker.Entities.DTOs;
using FitnessTracker.Interfaces;

namespace FitnessTracker.Services
{
    public class UserWorkoutService : IUserWorkoutService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserWorkoutService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task CreateUserWorkoutAsync(UserWorkoutDTO userWorkout, int userId)
        {
            var mappedNewUserWorkout = _mapper.Map<UserWorkout>(userWorkout);

            mappedNewUserWorkout.UserId = userId;

             _unitOfWork.UserWorkoutRepository.Create(mappedNewUserWorkout);

            if (_unitOfWork.HasChangesAsync()) await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<UserWorkoutDTO>> GetAllSpecificUserWorkoutsByName(int userId, string name)
        {
            var userWorkouts = await _unitOfWork.UserWorkoutRepository.GetAllAsync(
                x=>x.UserId == userId &&
                x.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase),
                include=>include.WorkoutExercises);

            if (userWorkouts is null) throw new KeyNotFoundException($"User with id: {userId} has no user workouts that has '{name}' in it's name");

            var result = userWorkouts.Select(
                userWorkout => _mapper.Map<UserWorkoutDTO>(userWorkout)).ToList();

            return result;
        }

        public async Task<IEnumerable<UserWorkoutDTO>> GetAllUserWorkouts(int userId)
        {
            var userWorkouts = await _unitOfWork.UserWorkoutRepository.GetAllAsync(
                x=>x.UserId == userId,include=>include.WorkoutExercises);

            if (userWorkouts is null) throw new KeyNotFoundException($"User with id: {userId} has no user workouts");

            var result = userWorkouts.Select(
                userworkout => _mapper.Map<UserWorkoutDTO>(userworkout)).ToList();

            return result;
        }
    }
}
