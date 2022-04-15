using AutoMapper;
using FitnessTracker.Entities;
using FitnessTracker.Entities.DTOs;
using FitnessTracker.Exceptions;
using FitnessTracker.Interfaces;

namespace FitnessTracker.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExerciseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExerciseDTO>> GetAllExercises()
        {
           var allExercises = await _unitOfWork.Exercise.GetAll(x=>x.ExerciseCategories);

            if (allExercises == null || !allExercises.Any()) throw new NullOrEmptyException("List of Exercises is null or empty");

            var mappedExercises = new List<ExerciseDTO>();

            foreach (var exercise in allExercises)
            {
                mappedExercises.Add(_mapper.Map<ExerciseDTO>(exercise));
            }
            
            return mappedExercises;
        }
       
    }
}
