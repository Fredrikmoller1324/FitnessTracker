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

        
    }
}
