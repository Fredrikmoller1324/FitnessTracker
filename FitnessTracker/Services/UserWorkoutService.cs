using AutoMapper;
using FitnessTracker.Data.Models.DTOs;
using FitnessTracker.Entities;
using FitnessTracker.Entities.DTOs;
using FitnessTracker.Exceptions;
using FitnessTracker.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Services
{
    public class UserWorkoutService : IUserWorkoutService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UserWorkoutService> _logger;

        public UserWorkoutService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UserWorkoutService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task CreateUserWorkoutAsync(UserWorkoutDTO userWorkout, int userId)
        {
            var mappedNewUserWorkout = _mapper.Map<UserWorkout>(userWorkout);

            mappedNewUserWorkout.UserId = userId;

            _unitOfWork.UserWorkoutRepository.Create(mappedNewUserWorkout);

            if (_unitOfWork.HasChangesAsync())
            {
                if (await _unitOfWork.CompleteAsync())
                {
                    _logger.LogInformation($"Succesfully CREATED UserWorkout with id: '{mappedNewUserWorkout.Id}'");
                }
            }
        }
        public async Task<UserWorkout> DeleteUserWorkoutAsync(string userWorkoutName, int userId)
        {
            var deletedUserWorkout = _unitOfWork.UserWorkoutRepository.Delete(x => x.UserId == userId && x.Name == userWorkoutName);

            if (deletedUserWorkout is null) throw new NullOrEmptyException($"deletion of userWorkout with name: '{userWorkoutName}' for user with id: '{userId}' has failed");

            if (_unitOfWork.HasChangesAsync())
            {
                if (await _unitOfWork.CompleteAsync())
                {
                    _logger.LogInformation($"Succesfully DELETED UserWorkout with id: '{deletedUserWorkout.Id}'");
                }
            }

            return deletedUserWorkout;
        }

        public async Task<IEnumerable<UserWorkoutDTO>> GetAllSpecificUserWorkoutsByName(int userId, FilterWorkoutsRequest request)
        {
            var userWorkouts = await _unitOfWork.UserWorkoutRepository.GetAllAsync(
                x => x.UserId == userId &&
                x.Name.Contains(request.WorkoutName),
               src => src
               .Include(x => x.WorkoutExercises)
               .ThenInclude(x => x.Exercise));

            userWorkouts = Filter(userWorkouts, request);

            if (userWorkouts is null) throw new KeyNotFoundException($"User with id: {userId} has no user workouts that has '{request.WorkoutName}' in it's name");

            var result = userWorkouts.Select(
                userWorkout => _mapper.Map<UserWorkoutDTO>(userWorkout)).ToList();

            return result;
        }

        public async Task<IEnumerable<UserWorkoutDTO>> GetAllUserWorkouts(int userId)
        {
            var userWorkouts = await _unitOfWork.UserWorkoutRepository.GetAllAsync(
                x => x.UserId == userId,
               src => src
               .Include(x => x.WorkoutExercises)
               .ThenInclude(x => x.Exercise));

            if (userWorkouts is null) throw new KeyNotFoundException($"User with id: {userId} has no user workouts");

            var result = userWorkouts.Select(
                userworkout => _mapper.Map<UserWorkoutDTO>(userworkout)).ToList();

            return result;
        }

        private IEnumerable<UserWorkout> Filter(IEnumerable<UserWorkout> userWorkouts, FilterWorkoutsRequest request)
        {
            if (request.ExerciseId != null && request.ExerciseId != 0)
            {
                userWorkouts = userWorkouts.Where(x => x.WorkoutExercises.Any(z => z.ExerciseId == request.ExerciseId));
            }

            userWorkouts = userWorkouts.Where(
                x => Convert.ToDateTime(x.Date.ToString("yyyy-MM-dd")) >= Convert.ToDateTime(request.StartDate.ToString("yyyy-MM-dd")) 
                && Convert.ToDateTime(x.Date.ToString("yyyy-MM-dd")) <= Convert.ToDateTime(request.EndDate.ToString("yyyy-MM-dd")));

            return userWorkouts;
        }
    }
}
